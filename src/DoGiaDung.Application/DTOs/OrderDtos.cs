using DoGiaDung.Domain.Enums;

namespace DoGiaDung.Application.DTOs;

public record CheckoutRequestDto(
    string? CustomerAddress,
    string? CustomerMessage,
    int PaymentMethod  // 2=PayPal, 3=Stripe
);

public record OrderDto(
    int TransactionId,
    decimal Amount,
    string Status,
    string? PaymentInfo,
    DateTime Created,
    List<OrderItemDto> Items
);

public record OrderItemDto(
    int ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal TotalPrice
);
