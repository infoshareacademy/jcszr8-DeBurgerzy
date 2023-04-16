using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class PackageService : IPackageService
    {
        private readonly IRepository<Package> _repository;

        public PackageService(IRepository<Package> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Package> GetAllPackages() => _repository.GetAll();

        public Package FindPackageByPackageNumber(int packageNumber)
        {
            var packages = _repository.GetAll();
            Package package = packages.FirstOrDefault(x => x.PackageNumber == packageNumber);
            if (package != null)
            {
                return package;
            }
            return null;
        }
        public bool DeletePackageByNumber(int packageNumber)
        {
            Package package = FindPackageByPackageNumber(packageNumber);
            if (package != null)
            {
                _repository.Delete(package);
                return true;
            }
            return false;
        }
        public bool Update(Package model)
        {
            var package = FindPackageByPackageNumber(model.PackageNumber);
            if (package ==null) return false;

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
            _repository.Update(package);
            return true;
        }

        /*
        public IEnumerable<Package> FindPackagesByCourierID(string courierId) => ReturnPackages(p => p.CourierId == courierId);

        public IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID) => ReturnPackages(p => p.DeliveryMachineJsonId == deliveryMachineID);

        public IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail) => ReturnPackages(p => p.SenderEmail == senderEmail);



        private IEnumerable<Package> ReturnPackages(Func<Package, bool> predicate)
        {
            IEnumerable<Package> packages = _repository.GetAll().Where(predicate);
            if (!packages.Any())
            {
                return null;
            }
            return packages;
        }
        */
    }
}