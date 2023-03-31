using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Rocky_Utility
{
    public class EmailSender : IEmailSender
    {
        // aqccdvhylnmvnzug - пароль для gmail

        private readonly IConfiguration _configuration;
        public MailKitSettings _mailKitSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            _mailKitSettings = _configuration.GetSection("MailKit").Get<MailKitSettings>();
            
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", _mailKitSettings.EmailAdress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", _mailKitSettings.Port, false);
                await client.AuthenticateAsync(_mailKitSettings.EmailAdress, _mailKitSettings.EmailSecretPass);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
