using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Models.BaseEntity;
using ParcelDistributionCenter.Model.Repositories;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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

        public IEnumerable<Courier> GetAll() => _courierRepository.GetAll();

        public List<Package> GetCourierPackages(string courierId)
        {
            var packages = _packageRepository.GetAll().Where(p => p.CourierId == courierId).ToList();

            return packages;
        }

        public Courier FindById(string id) => _courierRepository.Get(id);

        public void UnassignCouriersPackages(string CourierId)
        {
            IEnumerable<Package> packages = _packageRepository.GetAll().Where(p => p.CourierId == CourierId);
            packages.Select(p => p.CourierId = "Unassigned");
            foreach(Package p in packages)
            {
                _packageRepository.Update(p);
            }
        }

        public void Update(Courier model)
        {
            var courier = FindById(model.Id);
            courier.Name = model.Name;
            courier.Surname = model.Surname;
            courier.Email = model.Email;
            courier.Phone = model.Phone;
            _courierRepository.Update(courier);

        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return _packageRepository.GetAll().Where(p => p.CourierId == null);
        }

        public void AssignPackage(string packageNumber, string CourierId)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = CourierId;
            _packageRepository.Update(package);
        }
        public void UnassignPackage(string packageNumber)
        {
            var package = _packageRepository.GetAll().First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = null;
            _packageRepository.Update(package);
        }
    }
}