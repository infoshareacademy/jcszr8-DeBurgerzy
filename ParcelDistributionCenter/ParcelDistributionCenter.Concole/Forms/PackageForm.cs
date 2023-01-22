using ParcelDistributionCenter.ConsoleUI.Options;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Validators;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public static class PackageForm
    {
        public static void DisplayAllPackages()
        {
            Console.Clear();
            Console.ResetColor();
            Console.Title = "Display All Packages";
            foreach (Package courier in MemoryRepository.PackagesList)
            {
                DisplayForm.Display(courier);
            }
            Extensions.WriteEndMessage();
        }

        public static void DisplayPackageByNumber()
        {
            Package package = FindPackageByNumber();
            if (package != null)
            {
                DisplayForm.Display(package);
            }
            Extensions.WriteEndMessage();
        }

        public static Package FindPackageByNumber()
        {
            Console.Clear();
            Console.Title = "Find Package";
            Console.Write("Enter the package number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int packageNumber) && PackageValidator.ValidatePackageNumber(packageNumber))
            {
                Package package = PackageHandler.FindPackageByNumber(packageNumber);
                if (package != null)
                {
                    return package;
                }
                else
                {
                    Extensions.WriteMessageWithColor("\nThere is no package with the specified number!\n", ConsoleColor.Red);
                }
                return null;
            }
            else
            {
                Extensions.WriteMessageWithColor("\nIncorrect value provided. Number should 7 digits long.\n", ConsoleColor.Red);
            }
            return null;
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
                    DisplayForm.Display(package);
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
            Extensions.WriteEndMessage();
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
                    DisplayForm.Display(package);
                }
            }
            else
            {
                Extensions.WriteMessageWithColor("\nThere are no packages with given delivery machine ID!\n", ConsoleColor.Red);
            }
            Extensions.WriteEndMessage();
        }

        public static void SendPackage()
        {
            //Zebranie danych od użytkownika oraz ich walidacja
            //konstruktor Package
        }
    }
}