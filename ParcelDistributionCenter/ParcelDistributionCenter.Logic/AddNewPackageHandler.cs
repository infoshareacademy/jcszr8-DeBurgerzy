using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class AddNewPackageHandler : IAddNewPackageHandler
    {
        private readonly IMemoryRepository _memoryRepository;

        public AddNewPackageHandler(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        public bool AddNewPackage(Package package)
        {
            int packageNumber = GeneratePackageNumber();
            Status packageStatus = package.Status;
            string courierID = AssignCourierID();
            PackageSize packageSize = package.Size;
            string senderName = EnterFullName(package.SenderName);
            string senderEmail = EnterEmail(package.SenderEmail);
            string senderPhone = EnterPhone(package.SenderPhone);
            string senderAddress = EnterAddress(package.SenderAddress);
            string recipientName = EnterFullName(package.RecipientName);
            string recipientEmail = EnterEmail(package.RecipientEmail);
            string recipientPhone = EnterPhone(package.RecipientPhone);
            string deliveryAddress = EnterAddress(package.DeliveryAddress);
            string deliveryMachineID = AssignDeliveryMachineID();

            //to do zmiany, żeby zwracało false, jeśli się coś nie uda
            bool isAnyConditionNotSatisfied = true;
            if (isAnyConditionNotSatisfied)
            {
                return false;
            }
            Package newPackage = new(packageNumber, packageStatus, courierID, senderName, recipientName, packageSize, senderEmail, senderPhone,
                recipientEmail, recipientPhone, senderAddress, deliveryAddress, deliveryMachineID, DateTime.Now);
            _memoryRepository.PackagesList.Add(newPackage);
            return true;
        }

        protected static string EnterEmail(string email)
        {
            // Validate Email here
            //bool validationPassed = PackageValidator.ValidateEmail(email);
            return email;
        }

        protected static string EnterFullName(string name)
        {
            // Validate here name and surnmae together (so 2 capital letter, one space and at least 6 characters all together)
            //bool validationPassed = PackageValidator.ValidateName(name);
            return name;
        }

        protected static string EnterPhone(string phoneNumber)
        {
            // Validate Phone number here
            //bool validationPassed = PackageValidator.ValidatePhoneNumber(phoneNumber);
            return phoneNumber;
        }

        protected string AssignCourierID()
        {
            IEnumerable<string> courierIDs = _memoryRepository.CouriersList.Select(c => c.CourierId);
            return GenerateRandomID(courierIDs);
        }

        protected string AssignDeliveryMachineID()
        {
            IEnumerable<string> deliveryMachineIDs = _memoryRepository.DeliveryMachinesList.Select(c => c.DeliveryMachineId);
            return GenerateRandomID(deliveryMachineIDs);
        }

        protected int GeneratePackageNumber()
        {
            IEnumerable<int> packagesNumbers = _memoryRepository.PackagesList.Select(c => c.PackageNumber);
            Random rnd = new();
            int generatedNumber;
            do
            {
                generatedNumber = rnd.Next(1_000_000, 10_000_000);
            } while (!packagesNumbers.Contains(generatedNumber));
            return generatedNumber;
        }

        private static string EnterAddress(string address)
        {
            // Validate address here
            //bool validationPassed = PackageValidator.ValidateAddress(addressString);
            return address;
        }

        private static string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }
    }
}