using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface ICourierService
    {
        bool AddNewCourier(Courier courier);

        bool DeleteCourier(string courierId);

        Courier FindById(string id);

        IEnumerable<Courier> GetAll();

        IEnumerable<Package> GetCourierPackages(string courierId);

        void UnassignPackage(string packageNumber);

        void UpdateCourier(Courier model);
    }
}