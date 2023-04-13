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

        public List<AssignPackagesVM> GetUnassignedPackages()
        {
            Courier unknownCourier = new("Unassigned", "Unknown", "Unknown", "Unknown", "Unknown");
            var assignPackages = new List<AssignPackagesVM>();
            foreach (Package package in _packageRepository.GetAll())
            {
                List<string> CourisrsIds = _courierRepository.GetAll().Select(c => c.Id).ToList();
                Courier courier = _courierRepository.GetAll().FirstOrDefault(c => c.Id == package.CourierId);
                if (courier == null)
                {
                    courier = unknownCourier;
                }
                assignPackages.Add(
                        new AssignPackagesVM(
                        courier.Email,
                        courier.Name,
                        courier.Surname,
                        courier.Phone,
                        package.PackageNumber,
                        package.Status,
                        package.Size,
                        package.SenderEmail,
                        package.RecipientEmail,
                        package.DeliveryAddress,
                        package.Registered
                        )
                );
            }
            return assignPackages;
        }

        public void UnassignCouriersPackages(string CourierId)
        {
            _packageRepository.GetAll().Where(p => p.CourierId == CourierId).Select(p => p.CourierId = "Unassigned");
        }

        public void UnassignPackage(string packageNumber)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = "Unassigned";
        }
    }
}