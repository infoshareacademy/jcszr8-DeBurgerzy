using ParcelDistributionCenter.ConsoleUI.Options;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public class EditPackageForm : AddPackageForm
    {
        public static void EditExistingPackage()
        {
            Package package = PackageForm.FindPackageByNumber();
            if (package == null)
            {
                Extensions.WriteEndMessage();
            }
            if (package != null)
            {
                Console.Clear();
                Console.Title = "Edit Package";
                int counter = 1;
                Console.WriteLine("Edit package:\n");
                Console.WriteLine($"Enter '{counter++}' to edit Package Status");
                Console.WriteLine($"Enter '{counter++}' to edit Sender Name");
                Console.WriteLine($"Enter '{counter++}' to edit Sender Email");
                Console.WriteLine($"Enter '{counter++}' to edit Sender Phone");
                Console.WriteLine($"Enter '{counter++}' to edit Sender Address");
                Console.WriteLine($"Enter '{counter++}' to edit Recipient Name");
                Console.WriteLine($"Enter '{counter++}' to edit Recipient Email");
                Console.WriteLine($"Enter '{counter++}' to edit Recipient Phone");
                Console.WriteLine($"Enter '{counter++}' to edit Delivery Address");
                string enteredValue = Extensions.GetData("\nEnter number");
                Console.Clear();
                switch (enteredValue)
                {
                    case "1":
                        Status packageStatus = EnterPackageStatus();
                        package.Status = packageStatus;
                        break;

                    case "2":
                        string senderName = EnterFullName(_senderName);
                        package.SenderName = senderName;
                        break;

                    case "3":
                        string senderEmail = EnterEmail(_senderName);
                        package.SenderEmail = senderEmail;
                        break;

                    case "4":
                        string senderPhone = EnterPhone(_senderName);
                        package.SenderPhone = senderPhone;
                        break;

                    case "5":
                        string senderAddress = EnterAddress(_senderName);
                        package.SenderAddress = senderAddress;
                        break;

                    case "6":
                        string recipientName = EnterFullName(_recipientName);
                        package.RecipientName = recipientName;
                        break;

                    case "7":
                        string recipientEmail = EnterEmail(_recipientName);
                        package.RecipientEmail = recipientEmail;
                        break;

                    case "8":
                        string recipientPhone = EnterPhone(_recipientName);
                        package.RecipientPhone = recipientPhone;
                        break;

                    case "9":
                        string deliveryAddress = EnterAddress(_deliveryName);
                        package.DeliveryAddress = deliveryAddress;
                        break;

                    default:
                        Extensions.ReportError($"Incorrect data! Choose number between 1 to 6!");
                        EditExistingPackage();
                        break;
                }
                package.Registered = DateTime.Now;
                Extensions.WriteMessageWithColor($"\nPackage with number {package.PackageNumber} edited successfully!", ConsoleColor.Green);
                DisplayForm.Display(package);
                Extensions.WriteEndMessage();
            }
        }
    }
}