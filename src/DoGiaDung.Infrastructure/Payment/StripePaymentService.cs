using DoGiaDung.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace DoGiaDung.Infrastructure.Payment;

public class StripePaymentService : IPaymentService
{
    private readonly IConfiguration _config;

    public StripePaymentService(IConfiguration config)
    {
        _config = config;
        StripeConfiguration.ApiKey = config["Stripe:SecretKey"];
    }

    public async Task<string> CreateCheckoutSessionAsync(
        decimal amountEur, string orderRef, string customerEmail,
        string successUrl, string cancelUrl)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card", "sepa_debit" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "eur",
                        UnitAmount = (long)(amountEur * 100), // cents
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Pedido #{orderRef}",
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = successUrl,
            CancelUrl = cancelUrl,
            CustomerEmail = customerEmail,
            Metadata = new Dictionary<string, string>
            {
                { "order_ref", orderRef }
            },
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);
        return session.Url;
    }

    public async Task<string> HandleWebhookAsync(string json, string signatureHeader)
    {
        var webhookSecret = _config["Stripe:WebhookSecret"]!;
        try
        {
            var stripeEvent = EventUtility.ConstructEvent(json, signatureHeader, webhookSecret);
            if (stripeEvent.Type == Stripe.EventTypes.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                return session?.Metadata?.GetValueOrDefault("order_ref") ?? "";
            }
            return "";
        }
        catch (StripeException)
        {
            return "";
        }
    }
}
