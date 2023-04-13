using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class CourierService : ICourierService
    {
        private readonly IPackageServices _packageServices;
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<Package> _packageRepository;

        public CourierService(IRepository<Courier> courierRepository, IRepository<Package> packageRepository, IPackageServices packageServices)
        {
            _courierRepository = courierRepository;
            _packageRepository = packageRepository;
            _packageServices = packageServices;
        }

        public void Delete(Courier model)
        {
            var courier = FindById(model.CourierJsonId);
            _packageServices.UnassignCouriersPackages(courier.CourierJsonId);
            _courierRepository.Delete(courier);
        }

        public IEnumerable<Courier> GetAll() => _courierRepository.GetAll();

        public List<Package> GetCourierPackages(string courierId)
        {
            var packages = _packageRepository.GetAll().Where(p => p.CourierId == courierId).ToList();

            return packages;
        }

        public Courier FindById(string id) => _courierRepository.Get(id);

        public void Update(Courier model)
        {
            var courier = FindById(model.CourierJsonId);
            courier.Name = model.Name;
            courier.Surname = model.Surname;
            courier.Email = model.Email;
            courier.Phone = model.Phone;
        }
    }
}