using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Enums;
using DoGiaDung.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoGiaDung.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Transaction> _txRepo;
    private readonly IRepository<Order> _orderRepo;
    private readonly ICartService _cart;
    private readonly IPaymentService _payment;
    private readonly IEmailService _email;

    public OrderService(
        IRepository<Transaction> txRepo,
        IRepository<Order> orderRepo,
        ICartService cart,
        IPaymentService payment,
        IEmailService email)
    {
        _txRepo = txRepo;
        _orderRepo = orderRepo;
        _cart = cart;
        _payment = payment;
        _email = email;
    }

    public async Task<Result<OrderDto>> GetByIdAsync(int transactionId)
    {
        var tx = await _txRepo.Query()
            .Include(t => t.Orders).ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(t => t.TransactionId == transactionId);

        if (tx == null) return Result<OrderDto>.Failure("Pedido no encontrado.");

        return Result<OrderDto>.Success(MapToDto(tx));
    }

    public async Task<Result<IReadOnlyList<OrderDto>>> GetUserOrdersAsync(string userEmail, int page = 1, int pageSize = 10)
    {
        var txs = await _txRepo.Query()
            .Where(t => t.UserEmail == userEmail)
            .Include(t => t.Orders).ThenInclude(o => o.Product)
            .OrderByDescending(t => t.TransactionCreated)
            .Skip((page - 1) * pageSize).Take(pageSize)
            .ToListAsync();

        return Result<IReadOnlyList<OrderDto>>.Success(txs.Select(MapToDto).ToList());
    }

    public async Task<Result> CancelOrderAsync(int transactionId, string userEmail)
    {
        var tx = await _txRepo.Query()
            .FirstOrDefaultAsync(t => t.TransactionId == transactionId && t.UserEmail == userEmail);
        if (tx == null) return Result.Failure("Pedido no encontrado.");

        tx.TransactionStatus = TransactionStatus.Cancelled;
        await _txRepo.UpdateAsync(tx);
        return Result.Ok();
    }

    public async Task<Result> ConfirmPaymentAsync(string stripeSessionId)
    {
        // Stripe webhook handler — payment confirmed
        return Result.Ok();
    }

    /// <summary>Create transaction from cart and generate Stripe checkout URL</summary>
    public async Task<Result<string>> CreateCheckoutAsync(string userEmail, string userName, string userPhone, string address, string? message)
    {
        var cart = _cart.GetCart();
        if (cart.IsEmpty) return Result<string>.Failure("Carrito vacío.");

        var tx = new Transaction
        {
            UserEmail = userEmail,
            UserName = userName,
            UserPhone = userPhone,
            UserAddress = address,
            Message = message,
            TransactionStatus = TransactionStatus.Pending,
            TransactionCreated = DateTime.UtcNow,
            Payment = 3, // Stripe
            PaymentInfo = "Stripe",
            Amount = cart.Total,
            DelYn = "N",
            CreatedDt = DateTime.UtcNow
        };

        await _txRepo.AddAsync(tx);

        // Create order items
        foreach (var item in cart.Items)
        {
            var order = new Order
            {
                TransactionId = tx.TransactionId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Amount = item.Total,
                OrderStatus = 1,
                DelYn = "N"
            };
            await _orderRepo.AddAsync(order);
        }

        // Create Stripe session
        var successUrl = $"https://localhost:5001/Checkout/Success?tx={tx.TransactionId}";
        var cancelUrl = $"https://localhost:5001/Cart";
        var stripeUrl = await _payment.CreateCheckoutSessionAsync(
            cart.Total, tx.TransactionId.ToString(), userEmail, successUrl, cancelUrl);

        _cart.Clear();

        // Send email
        await _email.SendOrderConfirmationAsync(userEmail, userName, tx.TransactionId, cart.Total);

        return Result<string>.Success(stripeUrl);
    }

    private static OrderDto MapToDto(Transaction tx) => new(
        tx.TransactionId,
        tx.Amount,
        tx.TransactionStatus.ToString(),
        tx.PaymentInfo,
        tx.TransactionCreated,
        tx.Orders?.Select(o => new OrderItemDto(
            o.ProductId,
            o.Product?.ProductName ?? "Producto eliminado",
            o.Quantity,
            o.Amount / o.Quantity,
            o.Amount
        )).ToList() ?? new List<OrderItemDto>()
    );
}
