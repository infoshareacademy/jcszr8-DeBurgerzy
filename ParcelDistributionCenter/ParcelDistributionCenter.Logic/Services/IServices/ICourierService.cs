using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface ICourierService
    {
        public void AssignPackage(string packageNumber, string CourierId);

        public bool DeleteCourier(string courierId);

        public Courier FindById(string id);

        public IEnumerable<Courier> GetAll();

        public List<Package> GetCourierPackages(string courierId);

        public IEnumerable<Package> GetUnassignedPackages();

        public void UnassignPackage(string packageNumber);

        public void Update(Courier model);
    }
}