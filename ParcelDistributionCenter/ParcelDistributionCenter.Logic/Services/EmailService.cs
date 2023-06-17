using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using System.Text;

namespace ParcelDistributionCenter.Logic.Services
{
    public class EmailService : IEmailService
    {
        private readonly IReportService _reportService;
        private string emailAddress;
        private string host;
        private string password;
        private int port;

        public EmailService(IConfiguration configuration, IReportService reportService)
        {
            _reportService = reportService;
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
            string dataToBeSent = await GetReportPackagesFromDatabase();
            Timer timer = new(state => SendEmail(state.ToString()), dataToBeSent, (int)delay.TotalMilliseconds, (int)TimeSpan.FromDays(1).TotalMilliseconds);
        }

        private async Task<string> GetReportPackagesFromDatabase()
        {
            IEnumerable<ReportPackage> reportPackages = await _reportService.GetReportPackages();
            StringBuilder stringBuilder = new();
            double averageAddingDurationTime = reportPackages.Average(r => r.AddingDurationInSeconds);
            int bigPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Big);
            int mediumPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Medium);
            int smallPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Small);
            stringBuilder.Append("PACKAGES REPORT");
            stringBuilder.Append("Here you will find a packages report created for all packages ever added by clients.");
            stringBuilder.Append("------------------------------------------------------------------------------------");
            stringBuilder.Append($"Average duration time for package adding: {averageAddingDurationTime}");
            stringBuilder.Append($"Big Packages count: {bigPackagesCount}");
            stringBuilder.Append($"Medium Packages count: {mediumPackagesCount}");
            stringBuilder.Append($"Small Packages count: {smallPackagesCount}");
            return stringBuilder.ToString();
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