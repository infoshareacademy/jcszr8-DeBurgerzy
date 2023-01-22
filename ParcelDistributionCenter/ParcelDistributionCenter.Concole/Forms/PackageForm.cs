using ParcelDistributionCenter.ConsoleUI.Options;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public static class PackageForm
    {
        public static void DisplayAllPackages()
        {
            Console.Clear();
            Console.Title = "Display All Packages";
            foreach (Package courier in MemoryRepository.PackagesList)
            {
                Display(courier);
            }
            WriteEndMessage();
        }

        public static void FindPackageByNumber()
        {
            Console.Clear();
            Console.Title = "Find Package";
            Console.Write("Enter the package number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int packageNumber))
            {
                Package package = PackageHandler.FindPackageByNumber(packageNumber);
                if (package != null)
                {
                    Display(package);
                }
                else
                {
                    Extensions.WriteMessageWithColor("\nThere is no package with the specified number!\n", ConsoleColor.Red);
                }
                WriteEndMessage();
            }
            else
            {
                Extensions.WriteMessageWithColor("\nIncorrect value provided. Value should be a number.\n", ConsoleColor.Red);
                WriteEndMessage();
            }
        }

        public static void FindPackagesByCourierID()
        {
            Console.Clear();
            Console.Title = "Find Packages By Courier ID";
            Console.Write("Enter the courier ID: ");
            string input = Console.ReadLine();
            IEnumerable<Package> packages = PackageHandler.FindPackagesByCourierID(input);
            if (packages != null)
            {
                foreach (Package package in packages)
                {
                    Display(package);
                }
                int deliveredPackages = packages.Where(p => p.Status == Model.Enums.Status.Delivered).Count();
                int restPackages = packages.Count() - deliveredPackages;
                Extensions.WriteMessageWithColor($"Total packages delivered: {deliveredPackages}", ConsoleColor.DarkGreen);
                Extensions.WriteMessageWithColor($"All others packages: {restPackages}\n", ConsoleColor.DarkGreen);
            }
            else
            {
                Extensions.WriteMessageWithColor("\nThere are no packages with given courier ID!\n", ConsoleColor.Red);
            }
            WriteEndMessage();
        }

        public static void FindPackagesByDeliveryMachineID()
        {
            Console.Clear();
            Console.Title = "Find Packages By Delivery Machine ID";
            Console.Write("Enter the delivery machine ID: ");
            string input = Console.ReadLine();
            IEnumerable<Package> packages = PackageHandler.FindPackagesByDeliveryMachineID(input);
            if (packages != null)
            {
                foreach (Package package in packages)
                {
                    Display(package);
                }
            }
            else
            {
                Extensions.WriteMessageWithColor("\nThere are no packages with given delivery machine ID!\n", ConsoleColor.Red);
            }
            WriteEndMessage();
        }

        public static void SendPackage()
        {
            //Zebranie danych od użytkownika oraz ich walidacja
            //konstruktor Package
        }

        private static void Display(Package package)
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

        private static void WriteEndMessage()
        {
            Extensions.WriteMessageWithColor("Press any key to go back to main window.");
            Console.ReadKey();
        }
    }
}