namespace DoGiaDung.Application.Interfaces;

public interface IEmailService
{
    Task SendOrderConfirmationAsync(string toEmail, string userName, int transactionId, decimal amount);
    Task SendPasswordResetAsync(string toEmail, string resetLink);
    Task SendContactNotificationAsync(string fromName, string fromEmail, string message);
}
