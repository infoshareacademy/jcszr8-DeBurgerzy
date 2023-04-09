using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageService
    {
        bool DeletePackageByNumber(string packageNumber);

        Package FindPackageById(string packageNumber);

        IEnumerable<Package> FindPackagesByCourierID(string courierId);

        IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID);

        IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail);

        IEnumerable<Package> GetAllPackages();

        void Update(Package model);
    }
}