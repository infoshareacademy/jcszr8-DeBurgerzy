using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    public class PackageService : IPackageService
    {
        private readonly IDeliveryMachinesService _deliveryMachinesService;
        private readonly ICourierService _courierService;
        private readonly IRepository<Package> _packageRepository;

        public PackageService(IRepository<Package> repository, IDeliveryMachinesService deliveryMachinesService, ICourierService courierService)
        {
            _packageRepository = repository;
            _deliveryMachinesService = deliveryMachinesService;
            _courierService = courierService;
        }

        public void AssignCourier(string packageNumber, string CourierId)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == int.Parse(packageNumber));
            package.CourierId = CourierId;
            _packageRepository.Update(package);
        }

        public void AssignDeliveryMachine(string packageNumber, string deliveryMachineId)
        {
            Package package = _packageRepository.GetAll().First(p => p.PackageNumber == int.Parse(packageNumber));
            _deliveryMachinesService.AssignPackage(packageNumber, deliveryMachineId);
        }

        public bool DeletePackageByNumber(int packageNumber)
        {
            Package package = FindPackageByPackageNumber(packageNumber);
            if (package != null)
            {
                _packageRepository.Delete(package);
                return true;
            }
            return false;
        }

        public Package FindPackageByPackageNumber(int packageNumber)
        {
            var packages = _packageRepository.GetAll();
            Package package = packages.FirstOrDefault(x => x.PackageNumber == packageNumber);
            if (package != null)
            {
                return package;
            }
            return null;
        }

        public IEnumerable<Package> GetAllPackages() => _packageRepository.GetAll();

        public IEnumerable<int> GetAllPackagesNumber() => _packageRepository.GetAll().Select(p => p.PackageNumber);

        public IEnumerable<Package> GetUnassignedPackages()
        {
            var unassigned = _packageRepository.GetAll().Where(p => p.CourierId == null || p.DeliveryMachineId == null);
            foreach (Package package in unassigned)
            {
                if (package.DeliveryMachineId != null && package.CourierId == null)
                {
                    package.DeliveryMachine = _deliveryMachinesService.GetAll().First(d => d.Id == package.DeliveryMachineId);
                }
                else if (package.DeliveryMachineId == null && package.CourierId != null)
                {
                    package.Courier = _courierService.GetAll().First(c => c.Id == package.CourierId);
                }
            }
            return unassigned;
        }

        public bool Update(Package model)
        {
            var package = FindPackageByPackageNumber(model.PackageNumber);
            if (package == null) return false;

            package.Status = model.Status;
            package.SenderName = model.SenderName;
            package.RecipientName = model.RecipientName;
            package.SenderEmail = model.SenderEmail;
            package.SenderPhone = model.SenderPhone;
            package.RecipientEmail = model.RecipientEmail;
            package.RecipientPhone = model.RecipientPhone;
            package.SenderAddress = model.SenderAddress;
            package.DeliveryAddress = model.DeliveryAddress;
            package.Registered = model.Registered;
            package.Size = model.Size;
            _packageRepository.Update(package);
            return true;
        }
    }
}