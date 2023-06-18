namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IEmailService
    {
        int HourToSendEmail { get; set; }

        Task SendEmail();

        Task StartSendingEmails();
    }
}