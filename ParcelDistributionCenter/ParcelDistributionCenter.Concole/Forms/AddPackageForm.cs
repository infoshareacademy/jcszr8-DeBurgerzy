using ParcelDistributionCenter.ConsoleUI.Options;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Logic.Validators;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.ConsoleUI.Forms
{
    public class AddPackageForm
    {
        protected static readonly string _deliveryName = "Delivery";
        protected static readonly string _recipientName = "Recipient";
        protected static readonly string _senderName = "Sender";

        public static void AddNewPackage()
        {
            Console.Clear();
            int packageNumber = GeneratePackageNumber();
            Status packageStatus = EnterPackageStatus();
            string courierID = AssignCourierID();
            PackageSize packageSize = EnterPackageSize();
            string senderName = EnterFullName(_senderName);
            string senderEmail = EnterEmail(_senderName);
            string senderPhone = EnterPhone(_senderName);
            string senderAddress = EnterAddress(_senderName);
            string recipientName = EnterFullName(_recipientName);
            string recipientEmail = EnterEmail(_recipientName);
            string recipientPhone = EnterPhone(_recipientName);
            string deliveryAddress = EnterAddress(_deliveryName);
            string deliveryMachineID = AssignDeliveryMachineID();

            Package package = new(packageNumber, packageStatus, courierID, senderName, recipientName, packageSize, senderEmail, senderPhone,
                recipientEmail, recipientPhone, senderAddress, deliveryAddress, deliveryMachineID, DateTime.Now);

            MemoryRepository.PackagesList.Add(package);
            Extensions.WriteMessageWithColor($"\nPackage with number {package.PackageNumber} edited successfully!", ConsoleColor.Green);
            Extensions.WriteEndMessage();
        }

        protected static string AssignCourierID()
        {
            IEnumerable<string> courierIDs = MemoryRepository.CouriersList.Select(c => c.CourierId);
            return GenerateRandomID(courierIDs);
        }

        protected static string AssignDeliveryMachineID()
        {
            IEnumerable<string> deliveryMachineIDs = MemoryRepository.DeliveryMachinesList.Select(c => c.DeliveryMachineId);
            return GenerateRandomID(deliveryMachineIDs);
        }

        protected static string EnterAddress(string name)
        {
            Console.Clear();
            string addressTitle = $"{name} Address";
            string addressString = Extensions.GetData(addressTitle);

            bool validationPassed = PackageValidator.ValidateAddress(addressString);
            if (validationPassed)
            {
                return addressString;
            }
            Extensions.ReportError($"\nIncorrect data! {addressTitle} should contain at least 1 digit, 2 letters and 1 space separator!");
            //ConsoleKeyInfo keyPressed = Console.ReadKey();
            //Extensions.WriteEndMessage();
            //if (keyPressed.Key == ConsoleKey.Escape)
            //{
            //    return string.Empty;
            //}
            return EnterAddress(name);
        }

        protected static string EnterEmail(string name)
        {
            Console.Clear();
            string emailTitle = $"{name} Email";
            string emailString = Extensions.GetData(emailTitle);

            bool validationPassed = PackageValidator.ValidateEmail(emailString);
            if (validationPassed)
            {
                return emailString;
            }
            Extensions.ReportError($"\nIncorrect data! {emailTitle} should contain at least 6 chars, 1 '@' and 1 '.'!");
            Console.ReadKey();
            return EnterEmail(name);
        }

        protected static string EnterFullName(string name)
        {
            string senderName = GetSenderName(name);
            string senderSurame = GetSenderSurname(name);
            return $"{senderName} {senderSurame}";
        }

        protected static PackageSize EnterPackageSize()
        {
            Console.Clear();
            Console.WriteLine("Insert package size:\n");
            Console.WriteLine("Insert '1' if package size is 'Small'");
            Console.WriteLine("Insert '2' if package size is 'Medium'");
            Console.WriteLine("Insert '3' if package size is 'Big'");
            Console.WriteLine();
            string statusTitle = "Status delivery";
            string statusString = Extensions.GetData(statusTitle);
            switch (statusString)
            {
                case "1":
                    return PackageSize.Small;

                case "2":
                    return PackageSize.Medium;

                case "3":
                    return PackageSize.Big;

                default:
                    Extensions.ReportError($"\nIncorrect data! Choose number between 1 to 3!");
                    Console.ReadKey();
                    return EnterPackageSize();
            }
        }

        protected static Status EnterPackageStatus()
        {
            Console.Clear();
            Console.WriteLine("Insert status delivery:\n");
            Console.WriteLine("Press '1' if status is 'In preparation'");
            Console.WriteLine("Press '2' if status is 'Stored by sender'");
            Console.WriteLine("Press '3' if status is 'Stored in machine'");
            Console.WriteLine();
            string statusTitle = "Status delivery";
            string statusString = Extensions.GetData(statusTitle);
            switch (statusString)
            {
                case "1":
                    return Status.InPreparation;

                case "2":
                    return Status.StoredBySender;

                case "3":
                    return Status.StoredInMachine;

                default:
                    Extensions.ReportError($"\nIncorrect data! Choose number between 1 to 3!");
                    Console.ReadKey();
                    return EnterPackageStatus();
            }
        }

        protected static string EnterPhone(string name)
        {
            Console.Clear();
            string phoneTitle = $"{name} Phone";
            string phoneString = Extensions.GetData(phoneTitle);

            bool validationPassed = PackageValidator.ValidatePhoneNumber(phoneString);
            if (validationPassed)
            {
                return phoneString;
            }
            Extensions.ReportError($"\nIncorrect data! {phoneTitle} should have length between 7 and 14 digits!");
            Console.ReadKey();
            return EnterPhone(name);
        }

        protected static int GeneratePackageNumber()
        {
            IEnumerable<int> packagesNumbers = MemoryRepository.PackagesList.Select(c => c.PackageNumber);
            Random rnd = new();
            int generatedNumber;
            do
            {
                generatedNumber = rnd.Next(1_000_000, 10_000_000);
            } while (!packagesNumbers.Contains(generatedNumber));
            return generatedNumber;
        }

        protected static string GetSenderName(string name)
        {
            Console.Clear();
            string nameTitle = $"{name} Name";
            string senderString = Extensions.GetData(nameTitle);

            bool validationPassed = PackageValidator.ValidateName(senderString);
            if (validationPassed)
            {
                return senderString;
            }
            Extensions.ReportError($"\nIncorrect data! {nameTitle} should have at least one capital letter and to have length greater than 2!");
            Console.ReadKey();
            return GetSenderName(name);
        }

        protected static string GetSenderSurname(string name)
        {
            Console.Clear();
            string surnameTitle = $"{name} Surname";
            string senderString = Extensions.GetData(surnameTitle);

            bool validationPassed = PackageValidator.ValidateName(senderString);
            if (validationPassed)
            {
                return senderString;
            }
            Extensions.ReportError($"\nIncorrect data! {surnameTitle} should have at least one capital letter and to have length greater than 2!");
            Console.ReadKey();
            return GetSenderName(name);
        }

        private static string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }
    }
}