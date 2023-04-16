using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public interface ICourierService
    {
        public IEnumerable<Courier> GetAll();
        public List<Package> GetCourierPackages(string courierId);
        public bool DeleteCourier(string courierId);
        public Courier FindById(string id);
        public void Update(Courier model) { }
        public void Delete(Courier courier) { }
        public void AssignPackage(string packageNumber, string CourierId) { }
        public void UnassignPackage(string packageNumber) { }
        public IEnumerable<Package> GetUnassignedPackages();
    }
}