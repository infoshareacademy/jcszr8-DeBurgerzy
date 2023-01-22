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
            int packageNumber = EnterPackageNumber();
            Status packageStatus = EnterPackageStatus();
            string courierID = new Guid().ToString();
            PackageSize packageSize = EnterPackageSize();
            string senderName = EnterFullName(_senderName);
            string senderEmail = EnterEmail(_senderName);
            string senderPhone = EnterPhone(_senderName);
            string senderAddress = EnterAddress(_senderName);
            string recipientName = EnterFullName(_recipientName);
            string recipientEmail = EnterEmail(_recipientName);
            string recipientPhone = EnterPhone(_recipientName);
            string deliveryAddress = EnterAddress(_deliveryName);
            string deliveryMachineID = new Guid().ToString();

            MemoryRepository.PackagesList.Add(new Package(packageNumber, packageStatus, courierID, senderName, recipientName, packageSize, senderEmail, senderPhone,
                recipientEmail, recipientPhone, senderAddress, deliveryAddress, deliveryMachineID, DateTime.Now));
        }

        protected static string EnterAddress(string name)
        {
            string addressTitle = $"{name} Address";
            string addressString = Extensions.GetData(addressTitle);

            bool validationPassed = AddPackageValidator.CheckAddressValidation(addressString);
            if (validationPassed)
            {
                return addressString;
            }
            // Wpisać odpowiedni komunikat walidacji
            Extensions.ReportError($"Incorrect data! {addressTitle} should ...!");
            return EnterAddress(name);
        }

        protected static string EnterEmail(string name)
        {
            string emailTitle = $"{name} Email";
            string emailString = Extensions.GetData(emailTitle);

            bool validationPassed = AddPackageValidator.CheckEmailValidation(emailString);
            if (validationPassed)
            {
                return emailString;
            }
            // Wpisać odpowiedni komunikat walidacji
            Extensions.ReportError($"Incorrect data! {emailTitle} should ...!");
            return EnterEmail(name);
        }

        protected static string EnterFullName(string name)
        {
            string senderName = GetSenderName(name);
            string senderSurame = GetSenderSurname(name);
            return $"{senderName} {senderSurame}";
        }

        protected static int EnterPackageNumber()
        {
            //Zastanowić się, czy mam mieć sprawdzenie czy jest 7 liczb
            string packageTitle = "Package number";
            string packageString = Extensions.GetData(packageTitle);
            bool parsed = int.TryParse(packageString, out int packageinteger);
            if (parsed)
            {
                bool validationPassed = AddPackageValidator.CheckPackageNumberValidation(packageinteger);
                if (validationPassed)
                {
                    return packageinteger;
                }
            }
            Extensions.ReportError($"Incorrect data! {packageTitle} should be a number!");
            return EnterPackageNumber();
        }

        protected static PackageSize EnterPackageSize()
        {
            Console.WriteLine("Insert package size:\n");
            Console.WriteLine("Insert '1' if package size is 'Small'");
            Console.WriteLine("Insert '2' if package size is 'Medium'");
            Console.WriteLine("Insert '3' if package size is 'Big'");
            Console.WriteLine();
            string statusTitle = "Status delivery";
            string statusString = Extensions.GetData(statusTitle);
            bool parsed = int.TryParse(statusString, out int statusInteger);
            if (parsed)
            {
                switch (statusInteger)
                {
                    case 1:
                        return PackageSize.Small;

                    case 2:
                        return PackageSize.Medium;

                    case 3:
                        return PackageSize.Big;

                    default:
                        Extensions.ReportError($"Incorrect data! Choose number between 1 to 3!");
                        return EnterPackageSize();
                }
            }
            else
            {
                Extensions.ReportError($"Incorrect data! Choose number between 1 to 6!");
                return EnterPackageSize();
            }
        }

        protected static Status EnterPackageStatus()
        {
            Console.WriteLine("Insert status delivery:\n");
            Console.WriteLine("Press '1' if status is 'In preparation'");
            Console.WriteLine("Press '2' if status is 'Stored by sender'");
            Console.WriteLine("Press '3' if status is 'Stored in machine'");
            Console.WriteLine("Press '4' if status is 'In delivery'");
            Console.WriteLine("Press '5' if status is 'Delivered'");
            Console.WriteLine();
            string statusTitle = "Status delivery";
            string statusString = Extensions.GetData(statusTitle);
            bool parsed = int.TryParse(statusString, out int statusInteger);
            if (parsed)
            {
                switch (statusInteger)
                {
                    case 1:
                        return Status.InPreparation;

                    case 2:
                        return Status.StoredBySender;

                    case 3:
                        return Status.StoredInMachine;

                    case 4:
                        return Status.InDelivery;

                    case 5:
                        return Status.Delivered;

                    default:
                        Extensions.ReportError($"Incorrect data! Choose number between 1 to 6!");
                        return EnterPackageStatus();
                }
            }
            else
            {
                Extensions.ReportError($"Incorrect data! Choose number between 1 to 6!");
                return EnterPackageStatus();
            }
        }

        protected static string EnterPhone(string name)
        {
            string phoneTitle = $"{name} Phone";
            string phoneString = Extensions.GetData(phoneTitle);

            bool validationPassed = AddPackageValidator.CheckPhoneNumberValidation(phoneString);
            if (validationPassed)
            {
                return phoneString;
            }
            // Wpisać odpowiedni komunikat walidacji
            Extensions.ReportError($"Incorrect data! {phoneTitle} should ...!");
            return EnterPhone(name);
        }

        protected static string GetSenderName(string name)
        {
            string nameTitle = $"{name} Name";
            string senderString = Extensions.GetData(nameTitle);

            bool validationPassed = AddPackageValidator.CheckNameValidation(senderString);
            if (validationPassed)
            {
                return senderString;
            }
            // Wpisać odpowiedni komunikat walidacji
            Extensions.ReportError($"Incorrect data! {nameTitle} should ...!");
            return GetSenderName(name);
        }

        protected static string GetSenderSurname(string name)
        {
            string surnameTitle = $"{name} Surname";
            string senderString = Extensions.GetData(surnameTitle);

            bool validationPassed = AddPackageValidator.CheckNameValidation(senderString);
            if (validationPassed)
            {
                return senderString;
            }
            // Wpisać odpowiedni komunikat walidacji
            Extensions.ReportError($"Incorrect data! {surnameTitle} should ...!");
            return GetSenderName(name);
        }
    }
}