using ParcelDistributionCenter.Logic.Validators;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class AddNewPackageHandler : IAddNewPackageHandler
    {
        private readonly IMemoryRepository _memoryRepository;
        private readonly IPackageValidator _packageValidator;
        private readonly List<bool> validations = new();

        public AddNewPackageHandler(IMemoryRepository memoryRepository, IPackageValidator packageValidator)
        {
            _memoryRepository = memoryRepository;
            _packageValidator = packageValidator;
        }

        public bool AddNewPackage(Package package)
        {
            int packageNumber = GeneratePackageNumber();
            ValidatePackageStatus(package.Status);
            ValidatePackageSize(package.Size);
            string courierID = AssignCourierID();
            ValidateFullName(package.SenderName);
            ValidateEmail(package.SenderEmail);
            ValidatePhone(package.SenderPhone);
            ValidateAddress(package.SenderAddress);
            ValidateFullName(package.RecipientName);
            ValidateEmail(package.RecipientEmail);
            ValidatePhone(package.RecipientPhone);
            ValidateAddress(package.DeliveryAddress);
            string deliveryMachineID = AssignDeliveryMachineID();

            if (validations.Any(v => v == false))
            {
                return false;
            }

            Package newPackage = new(packageNumber, package.Status, courierID, package.SenderName, package.RecipientName, package.Size, package.SenderEmail, package.SenderPhone,
                package.RecipientEmail, package.RecipientPhone, package.SenderAddress, package.DeliveryAddress, deliveryMachineID, DateTime.Now);
            _memoryRepository.PackagesList.Add(newPackage);
            return true;
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

        protected void ValidateEmail(string email)
        {
            bool emailValidation = _packageValidator.ValidateEmail(email);
            validations.Add(emailValidation);
        }

        protected void ValidateFullName(string name)
        {
            bool fullNameValidation = _packageValidator.ValidateName(name);
            validations.Add(fullNameValidation);
        }

        protected void ValidatePhone(string phoneNumber)
        {
            bool phoneValidation = _packageValidator.ValidatePhoneNumber(phoneNumber);
            validations.Add(phoneValidation);
        }

        private static string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }

        private void ValidateAddress(string address)
        {
            bool addressValidation = _packageValidator.ValidateAddress(address);
            validations.Add(addressValidation);
        }

        private void ValidatePackageSize(PackageSize? packageSize)
        {
            bool packageSizeValidation = packageSize != null;
            validations.Add(packageSizeValidation);
        }

        private void ValidatePackageStatus(Status? status)
        {
            bool statusValidation = status != null;
            validations.Add(statusValidation);
        }
    }
}