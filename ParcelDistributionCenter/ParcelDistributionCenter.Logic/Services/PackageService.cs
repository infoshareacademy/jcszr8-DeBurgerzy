using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
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

        public IEnumerable<Package> GetAllPackages() => _repository.GetAll();

        public IEnumerable<int> GetAllPackagesNumber() => _repository.GetAll().Select(p => p.PackageNumber);

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
            _repository.Update(package);
            return true;
        }
    }
}