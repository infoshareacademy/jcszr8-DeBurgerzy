using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Logic.Validators;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class AddNewPackageService : IAddNewPackageService
    {
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<DeliveryMachine> _deliverMachineRepository;
        private readonly IRepository<Package> _packageRepository;
        private readonly IPackageValidator _packageValidator;
        private readonly List<bool> validations = new();

        public AddNewPackageService(IRepository<Package> packageRepository, IRepository<Courier> courierRepository, IRepository<DeliveryMachine> deliverMachineRepository, IPackageValidator packageValidator)
        {
            _packageRepository = packageRepository;
            _courierRepository = courierRepository;
            _deliverMachineRepository = deliverMachineRepository;
            _packageValidator = packageValidator;
        }

        public bool AddNewPackage(ref Package package)
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
            string deliveryMachineID = AssignDeliveryMachineID(package.Size);

            if (validations.Any(v => v == false) || deliveryMachineID == null)
            {
                return false;
            }
            _packageRepository.Insert(package);
            return true;
        }

        protected string AssignCourierID()
        {
            IEnumerable<string> courierIDs = _courierRepository.GetAll().Select(c => c.CourierJsonId);
            return GenerateRandomID(courierIDs);
        }

        private static string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }

        private string AssignDeliveryMachineID(PackageSize size)
        {
            IEnumerable<string> deliveryMachineIDs = _deliverMachineRepository.GetAll().Select(c => c.Id);
            string generatedId = GenerateRandomID(deliveryMachineIDs);
            DeliveryMachine deliveryMachine = _deliverMachineRepository.Get(generatedId);
            if (deliveryMachine != null)
            {
                switch (size)
                {
                    case PackageSize.Big:
                        if (deliveryMachine.BigLockersCount > 0)
                        {
                            return generatedId;
                        }
                        return null;

                    case PackageSize.Medium:
                        if (deliveryMachine.MediumLockersCount > 0)
                        {
                            return generatedId;
                        }
                        return null;

                    case PackageSize.Small:
                        if (deliveryMachine.SmallLockersCount > 0)
                        {
                            return generatedId;
                        }
                        return null;

                    default:
                        return null;
                }
            }
            return null;
        }

        private int GeneratePackageNumber()
        {
            IEnumerable<int> packagesNumbers = _packageRepository.GetAll().Select(c => c.PackageNumber);
            Random rnd = new();
            int generatedNumber;
            do
            {
                generatedNumber = rnd.Next(1_000_000, 10_000_000);
            } while (packagesNumbers.Contains(generatedNumber));
            return generatedNumber;
        }

        private void ValidateAddress(string address)
        {
            bool addressValidation = _packageValidator.ValidateAddress(address);
            validations.Add(addressValidation);
        }

        private void ValidateEmail(string email)
        {
            bool emailValidation = _packageValidator.ValidateEmail(email);
            validations.Add(emailValidation);
        }

        private void ValidateFullName(string name)
        {
            bool fullNameValidation = _packageValidator.ValidateName(name);
            validations.Add(fullNameValidation);
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

        private void ValidatePhone(string phoneNumber)
        {
            bool phoneValidation = _packageValidator.ValidatePhoneNumber(phoneNumber);
            validations.Add(phoneValidation);
        }
    }
}