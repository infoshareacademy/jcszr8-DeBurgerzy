using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageService
    {
        void AssignCourier(string packageNumber, string CourierId);

        void AssignDeliveryMachine(string packageNumber, string deliveryMachineId);

        bool DeletePackageByNumber(int packageNumber);

        public Package FindPackageByPackageNumber(int packageNumber);

        IEnumerable<Package> GetAllPackages();

        public IEnumerable<int> GetAllPackagesNumber();

        IEnumerable<Package> GetUnassignedPackages();

        bool Update(Package model);
    }
}