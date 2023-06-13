using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using ParcelDistributionCenter.Logic.Services.IServices;
using System.Net.Http.Json;

namespace ParcelDistributionCenter.Logic.Services
{
    public class EmailService : IEmailService
    {
        private readonly AuthorizationHelper _authorizationHelper;
        private readonly HttpClient _httpClient;
        private string emailAddress;
        private string host;
        private string password;
        private int port;

        public EmailService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _authorizationHelper = new AuthorizationHelper(httpClient, configuration);
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

        public async Task StartSendingEmails()
        {
            DateTime now = DateTime.Now;
            DateTime nextSendingEmailOccurence = new(now.Year, now.Month, now.Day, 15, 0, 0);
            if (now > nextSendingEmailOccurence)
            {
                nextSendingEmailOccurence.AddDays(1);
            }
            TimeSpan delay = nextSendingEmailOccurence - now;
            string dataToBeSent = await GetReportFromDatabase();
            Timer timer = new(state => SendEmail(state.ToString()), dataToBeSent, (int)delay.TotalMilliseconds, (int)TimeSpan.FromDays(1).TotalMilliseconds);
        }

        private async Task<string> GetReportFromDatabase()
        {
            _authorizationHelper.AddAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<string>("reports/users");
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