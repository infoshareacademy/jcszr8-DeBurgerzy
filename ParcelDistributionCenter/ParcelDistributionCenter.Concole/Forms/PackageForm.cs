using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public static class PackageForm
    {
        public static void Display(Package package)
        {
            Console.WriteLine
                (
                  $" Package number: {package.PackageNumber}\n" +
                  $" Package size: {package.Size} \n" +
                  $" Package status: {package.Status} \n" +
                  $" Sender data: {$"{package.SenderEmail}, {package.SenderName}, {package.SenderAddress}, {package.SenderPhone}"} \n" +
                  $" Recipient data: {$"{package.RecipientEmail}, {package.RecipientName}, {package.DeliveryAddress}, {package.RecipientPhone}"} \n" +
                  $" Delivery machine id: {package.DeliveryMachneId} \n" +
                  $" Send date: {package.Registered} \n" +
                  $" Courier id: {package.CourierId} \n"
                );
        }
        public static void DisplayAllPackages()
        {
            foreach (Package courier in MemoryRepository.PackagesList)
            {
                Display(courier);
            }
        }
        public static void FindPackageByNumber() 
        {
            Console.Clear();
            Console.Title="Find_Package";
            Console.Write("Enter the package number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int packageNumber))
            {
                Package p=PackageHandler.FindPackageByNumber(packageNumber);
                Display(p);
            }
            else
            {
                Console.WriteLine("Incorrect value provided");
                Console.ReadKey();
                Console.Clear();
            }
        }
        

        public static void SendPackage()
        {
            //Zebranie danych od użytkownika oraz ich walidacja

            //konstruktor Package
        }
    }
}