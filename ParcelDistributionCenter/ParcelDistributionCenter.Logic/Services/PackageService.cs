using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    public class PackageService : IPackageService
    {
        private readonly IRepository<Package> _repository;

        public PackageService(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public bool DeletePackageByNumber(string id)
        {
            Package package = FindPackageById(id);
            if (package != null)
            {
                _repository.Delete(package);
                return true;
            }
            return false;
        }

        public IEnumerable<Package> FindAll() => _repository.GetAll();

        public Package FindPackageById(string id)
        {
            Package package = _repository.Get(id);
            if (package != null)
            {
                return package;
            }
            return null;
        }

        public IEnumerable<Package> FindPackagesByCourierID(string courierId) => ReturnPackages(p => p.CourierId == courierId);

        public IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID) => ReturnPackages(p => p.DeliveryMachineId == deliveryMachineID);

        public IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail) => ReturnPackages(p => p.SenderEmail == senderEmail);

        public void Update(Package model)
        {
            var package = FindPackageById(model.Id);
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

        private IEnumerable<Package> ReturnPackages(Func<Package, bool> predicate)
        {
            IEnumerable<Package> packages = _repository.GetAll().Where(predicate);
            if (!packages.Any())
            {
                return null;
            }
            return packages;
        }
    }
}