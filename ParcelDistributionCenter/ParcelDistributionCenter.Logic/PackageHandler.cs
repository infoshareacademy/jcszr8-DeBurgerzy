using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class PackageHandler : IPackageHandler
    {
        private readonly IMemoryRepository _memoryRepository;

        public PackageHandler(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }


        public Package FindPackageByNumber(int packageNumber)
        {
            Package package = _memoryRepository.PackagesList.FirstOrDefault(p => p.PackageNumber == packageNumber);
            if (package == default)
            {
                return null;
            }
            return package;
        }

        public IEnumerable<Package> FindPackagesByCourierID(string courierId) => ReturnPackages(p => p.CourierId == courierId);

        public IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID) => ReturnPackages(p => p.DeliveryMachineId == deliveryMachineID);

        public IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail) => ReturnPackages(p => p.SenderEmail == senderEmail);

        public void Update(Package model)
        {
            var package = FindPackageByNumber(model.PackageNumber);
            package.Status = model.Status;
            package.CourierId = model.CourierId;
            package.SenderName = model.SenderName;
            package.RecipientName = model.RecipientName;
            package.SenderEmail = model.SenderEmail;
            package.SenderPhone = model.SenderPhone;
            package.RecipientEmail = model.RecipientEmail;
            package.RecipientPhone = model.RecipientPhone;
            package.SenderAddress = model.SenderAddress;
            package.DeliveryAddress = model.DeliveryAddress;
            package.DeliveryMachineId = model.DeliveryMachineId;
            package.Registered = model.Registered;
        }
        public static IEnumerable<Package> FindAll() => MemoryRepository.PackagesList;

        private IEnumerable<Package> ReturnPackages(Func<Package, bool> predicate)
        {
            IEnumerable<Package> packages = _memoryRepository.PackagesList.Where(predicate);
            if (!packages.Any())
            {
                return null;
            }
            return packages;
        }
    }
}