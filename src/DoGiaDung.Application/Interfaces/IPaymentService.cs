namespace DoGiaDung.Application.Interfaces;

public interface IPaymentService
{
    /// <summary>Tạo Stripe Checkout session URL</summary>
    Task<string> CreateCheckoutSessionAsync(decimal amountEur, string orderRef, string customerEmail, string successUrl, string cancelUrl);

    /// <summary>Xác nhận thanh toán từ Stripe webhook</summary>
    Task<string> HandleWebhookAsync(string json, string signatureHeader);
}
