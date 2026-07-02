using System.Net;
using System.Net.Mail;
using DoGiaDung.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DoGiaDung.Infrastructure.Email;

public class SmtpEmailService : IEmailService
{
    private readonly IConfiguration _config;

    public SmtpEmailService(IConfiguration config) => _config = config;

    public async Task SendOrderConfirmationAsync(string toEmail, string userName, int transactionId, decimal amount)
    {
        var subject = "¡Pedido confirmado! Gracias por tu compra";
        var body = $@"
<h2>Hola {userName},</h2>
<p>Tu pedido #{transactionId} ha sido confirmado.</p>
<p>Total: {amount:C2} (IVA incluido)</p>
<p>Gracias por confiar en nosotros.</p>";
        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendPasswordResetAsync(string toEmail, string resetLink)
    {
        var subject = "Restablecer tu contraseña";
        var body = $@"
<h2>Restablecer contraseña</h2>
<p>Haz clic en el siguiente enlace para restablecer tu contraseña:</p>
<p><a href='{resetLink}'>{resetLink}</a></p>
<p>Si no solicitaste esto, ignora este mensaje.</p>";
        await SendEmailAsync(toEmail, subject, body);
    }

    public async Task SendContactNotificationAsync(string fromName, string fromEmail, string message)
    {
        var adminEmail = _config["Email:AdminAddress"] ?? "admin@dogiadung.es";
        var subject = $"Nuevo mensaje de contacto de {fromName}";
        var body = $"De: {fromName} ({fromEmail})<br/>Mensaje: {message}";
        await SendEmailAsync(adminEmail, subject, body);
    }

    private async Task SendEmailAsync(string to, string subject, string body)
    {
        using var smtp = new SmtpClient
        {
            Host = _config["Email:Host"] ?? "smtp.gmail.com",
            Port = int.Parse(_config["Email:Port"] ?? "587"),
            EnableSsl = bool.Parse(_config["Email:EnableSsl"] ?? "true"),
            Credentials = new NetworkCredential(
                _config["Email:From"],
                _config["Email:Password"])
        };

        using var message = new MailMessage(_config["Email:From"]!, to, subject, body)
        {
            IsBodyHtml = true
        };

        await smtp.SendMailAsync(message);
    }
}
