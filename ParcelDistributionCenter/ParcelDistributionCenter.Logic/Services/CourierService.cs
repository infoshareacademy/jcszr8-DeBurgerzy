using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class CourierService : ICourierService
    {
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<Package> _packageRepository;

        public CourierService(IRepository<Courier> courierRepository, IRepository<Package> packageRepository)
        {
            _courierRepository = courierRepository;
            _packageRepository = packageRepository;
        }

        public bool DeleteCourier(string id)
        {
            var courier = FindById(id);
            if (courier != null)
            {
                UnassignCouriersPackages(id);
                _courierRepository.Delete(courier);
                return true;
            }
            return false;
        }

        public Courier FindById(string id) => _courierRepository.Get(id, c => c.Packages);

        public IEnumerable<Courier> GetAll() => _courierRepository.GetAll(c => c.Packages);

        public IEnumerable<Package> GetCourierPackages(string courierId) => _packageRepository.GetAll().Where(p => p.CourierId == courierId);

        public void UnassignCouriersPackages(string courierId)
        {
            IEnumerable<Package> packages = _packageRepository.GetAll().Where(p => p.CourierId == courierId);
            foreach (Package p in packages)
            {
                _packageRepository.Update(p);
            }
        }

        public void UnassignPackage(string packageNumber)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = null;
            _packageRepository.Update(package);
        }

        public void UpdateCourier(Courier model)
        {
            var courier = FindById(model.Id);
            courier.Name = model.Name;
            courier.Surname = model.Surname;
            courier.Email = model.Email;
            courier.Phone = model.Phone;
            _courierRepository.Update(courier);
        }

        public bool AddNewCourier(Courier courier)
        {
            _courierRepository.Insert(courier);
            return true;
        }
    }
}