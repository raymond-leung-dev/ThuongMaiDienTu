using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;

namespace DoGiaDung.Application.Interfaces;

public interface IOrderService
{
    Task<Result<OrderDto>> GetByIdAsync(int transactionId);
    Task<Result<IReadOnlyList<OrderDto>>> GetUserOrdersAsync(string userEmail, int page = 1, int pageSize = 10);
    Task<Result> CancelOrderAsync(int transactionId, string userEmail);
    Task<Result> ConfirmPaymentAsync(string stripeSessionId);
}
