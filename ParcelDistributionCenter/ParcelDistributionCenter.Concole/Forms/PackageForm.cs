using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Enums;
using System;
using System.Drawing;

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
            Console.Clear();
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
        public static void AddPackage()
        {
            //Zebranie danych od użytkownika oraz ich walidacja

            //konstruktor Package
            //MemoryRepository.PackagesList // lista paczek
            //
            //dodawanie użytkownika////////////////////////////////////////////////////////////
            Console.Clear();
            //Wprowadzanie numeru paczki(na razie, bedzie generowana pozniej
            int packageNumber2 = 0;
            bool ifDone1 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Insert package number");
                var packageNumber1 = Console.ReadLine();
                if (int.TryParse(packageNumber1, out packageNumber2))
                {
                    ifDone1 = true;
                }
            } while (ifDone1 == false);

            // wprowadzanie statusu paczki
            Status Status2;
            bool ifDone2 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Insert status delivery(in preparation itp");
                string Status1 = Console.ReadLine();              
               
                if (Status.TryParse(Status1, out Status2))
                {
                    ifDone2 = true;
                }

            } while (ifDone2 == false);

            //Wprowadzanie courier_id
            Console.WriteLine("Insert courier ID :");
            var courierID = Console.ReadLine();
            Console.Clear();

            //Wprowadzanie danych nadawcy
            Console.WriteLine("Insert name and surname sender :");
            var senderName = Console.ReadLine();
            while (senderName.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full name and surname sender:");
                senderName = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie danych odbiorcy
            Console.WriteLine("Insert name and surname sender :");
            var recipientName = Console.ReadLine();
            while (recipientName.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full name and surname sender:");
                recipientName = Console.ReadLine();
            }
            Console.Clear();
            // wprowadzanie rozmiaru paczki
            PackageSize packageSize2;
            bool ifDone3 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Insert size delivery(small, medium, big");
                var packageSize = Console.ReadLine();
                bool x = PackageSize.TryParse(packageSize, out packageSize2);
                if (x==true)
                {
                    ifDone3 = true;
                }

            } while (ifDone3 == false);

            //Wprowadzanie emaila nadawcy
            Console.WriteLine("Insert email sender :");
            var senderEmail = Console.ReadLine();
            while (senderEmail.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full email:");
                senderEmail = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie numeru telefonu nadawcy
            Console.WriteLine("Insert phone number sender :");
            var senderPhone = Console.ReadLine();
            while (senderPhone.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full phone number sender:");
                senderPhone = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie emaila odbiorcy
            Console.WriteLine("Insert email recipient :");
            var recipientEmail = Console.ReadLine();
            while (recipientEmail.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full email:");
                recipientEmail = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie numeru telefonu odbiorcy
            Console.WriteLine("Insert phone number recipient :");
            var recipientPhone = Console.ReadLine();
            while (recipientPhone.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full phone number recipient:");
                recipientPhone = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie adresu nadawcy
            Console.WriteLine("Insert adres sender :");
            var senderAddres = Console.ReadLine();
            while (senderAddres.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full adres sender:");
                senderAddres = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie adresu odbiorcy
            Console.WriteLine("Insert adres delivery :");
            var deliveryAddres = Console.ReadLine();
            while (deliveryAddres.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full adres delivery:");
                deliveryAddres = Console.ReadLine();
            }
            Console.Clear();

            //Wprowadzanie Id paczkomatu
            Console.WriteLine("Insert delivery machine ID :");
            var deliveryMachineID = Console.ReadLine();
            while (deliveryMachineID.Length < 2)
            {
                Console.Clear();
                Console.WriteLine("Insert full  delivery machine ID:");
                deliveryMachineID = Console.ReadLine();
            }
            Console.Clear();
            //data rejestracji
            DateTime registered = DateTime.Now;

            //Generowanie nowego użytkownika
           //List<Package>  PackagesList2= new List<Package>();
            //MemoryRepository.PackagesList
            MemoryRepository.PackagesList.Add(new Package(packageNumber2, Status2, courierID, senderName, recipientName, packageSize2, senderEmail, senderPhone, recipientEmail, recipientPhone, senderAddres, deliveryAddres, deliveryMachineID, registered)); 
        }
    }
}

