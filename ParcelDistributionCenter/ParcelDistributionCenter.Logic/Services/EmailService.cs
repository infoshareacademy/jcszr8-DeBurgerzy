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
        public int HourToSendEmail { get; set; } = 15;

        public EmailService(IConfiguration configuration, IReportService reportService)
        {
            _reportService = reportService;
            SetConnectionValuesByConfiguration(configuration);
        }

        public async Task SendEmail()
        {
            string dataToBeSent = await GetReportPackagesFromDatabase();

            MimeMessage email = new();
            email.From.Add(MailboxAddress.Parse(emailAddress));
            email.To.Add(MailboxAddress.Parse(emailAddress));
            email.Subject = $"Report email {DateTime.Now}";
            email.Body = new TextPart(TextFormat.Html) { Text = dataToBeSent };

            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailAddress, password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task StartSendingEmails()
        {
            await Task.Run(() =>
            {
                DateTime now = DateTime.Now;
                DateTime nextSendingEmailOccurence = new(now.Year, now.Month, now.Day, HourToSendEmail, 0, 0);
                if (now > nextSendingEmailOccurence)
                {
                    nextSendingEmailOccurence.AddDays(1);
                }
                TimeSpan delay = nextSendingEmailOccurence - now;
                Timer timer = new(async _ => await SendEmail(), null, (int)delay.TotalMilliseconds, (int)TimeSpan.FromDays(1).TotalMilliseconds);
            });
        }

        private async Task<string> GetReportPackagesFromDatabase()
        {
            IEnumerable<ReportPackage> reportPackages = await _reportService.GetReportPackages();
            StringBuilder stringBuilder = new();
            double averageAddingDurationTime = Math.Round(reportPackages.Average(r => r.AddingDurationInSeconds));
            int bigPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Big);
            int mediumPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Medium);
            int smallPackagesCount = reportPackages.Count(r => r.Size == Model.Enums.PackageSize.Small);
            stringBuilder.Append("PACKAGES REPORT.<br>");
            stringBuilder.Append("Here you will find a packages report created for all packages ever added by clients.<br>");
            stringBuilder.Append("------------------------------------------------------------------------------------.<br>");
            stringBuilder.Append($"Average duration time for package adding: {averageAddingDurationTime}<br>");
            stringBuilder.Append($"Big Packages count: {bigPackagesCount}<br>");
            stringBuilder.Append($"Medium Packages count: {mediumPackagesCount}<br>");
            stringBuilder.Append($"Small Packages count: {smallPackagesCount}<br>");
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