using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public interface ICourierService
    {
        public IEnumerable<Courier> GetAll();
        public List<Package> GetCourierPackages(string courierId);

        public Courier FindById(string id);
        public void Update(Courier model) { }
        public void Delete(Courier courier) { }
    }
}