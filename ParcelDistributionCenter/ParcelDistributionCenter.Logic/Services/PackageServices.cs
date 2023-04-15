using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class PackageServices : IPackageServices
    {
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<Package> _packageRepository;

        public PackageServices(IRepository<Package> packageRepository, IRepository<Courier> courierRepository)
        {
            _packageRepository = packageRepository;
            _courierRepository = courierRepository;
        }

        public void AssignPackage(string packageNumber, string CourierId)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = CourierId;
        }

        public void UnassignPackage(string packageNumber)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = "Unassigned";
        }
    }
}