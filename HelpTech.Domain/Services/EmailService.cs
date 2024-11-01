using System.Net.Mail;

namespace HelpTech.API.Services
{
    // Services/EmailService.cs
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage("helptechmailetec@gmail.com", to, subject, body);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }

}
