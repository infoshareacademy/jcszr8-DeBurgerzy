using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface ICourierService
    {
        void AssignPackage(string packageNumber, string CourierId);

        bool DeleteCourier(string courierId);

        Courier FindById(string id);

        IEnumerable<Courier> GetAll();

        IEnumerable<Package> GetCourierPackages(string courierId);

        IEnumerable<Package> GetUnassignedPackages();

        void UnassignPackage(string packageNumber);

        void Update(Courier model);

        bool AddNewCourier(Courier courier);
    }
}