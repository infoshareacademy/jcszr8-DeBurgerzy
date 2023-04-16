using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public class DisplayForm
    {
        public static void Display(Package package)
        {
            Console.WriteLine();
            Console.WriteLine
                (
                  $" Package number: {package.PackageNumber}\n" +
                  $" Package size: {package.Size} \n" +
                  $" Package status: {package.Status} \n" +
                  $" Sender data: {$"{package.SenderEmail}, {package.SenderName}, {package.SenderAddress}, {package.SenderPhone}"} \n" +
                  $" Recipient data: {$"{package.RecipientEmail}, {package.RecipientName}, {package.DeliveryAddress}, {package.RecipientPhone}"} \n" +
                  $" Delivery machine id: {package.DeliveryMachineId} \n" +
                  $" Send date: {package.Registered} \n" +
                  $" Courier id: {package.CourierId} \n"
                );
        }
    }
}