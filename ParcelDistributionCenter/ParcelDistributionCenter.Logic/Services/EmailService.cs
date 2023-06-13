using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using ParcelDistributionCenter.Logic.Services.IServices;

namespace ParcelDistributionCenter.Logic.Services
{
    public class EmailService : IEmailService
    {
        private string emailAddress;
        private string host;
        private string password;
        private int port;

        public EmailService(IConfiguration configuration)
        {
            SetConnectionValuesByConfiguration(configuration);
        }

        public void SendEmail(string body)
        {
            MimeMessage email = new();
            email.From.Add(MailboxAddress.Parse(emailAddress));
            email.To.Add(MailboxAddress.Parse(emailAddress));
            email.Subject = $"Report email {DateTime.Now}";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailAddress, password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private void SetConnectionValuesByConfiguration(IConfiguration configuration)
        {
            string header = "EmailConfiguration:";
            emailAddress = configuration[$"{header}EmailUserName"];
            host = configuration[$"{header}EmailHost"];
            password = configuration[$"{header}EmailPassword"];
            port = int.Parse(configuration[$"{header}EmailPort"]);
        }
    }
}