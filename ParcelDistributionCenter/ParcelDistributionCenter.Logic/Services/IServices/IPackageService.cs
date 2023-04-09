using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageService
    {
        bool DeletePackageByNumber(string packageNumber);

        IEnumerable<Package> FindAll();

        Package FindPackageById(string packageNumber);

        IEnumerable<Package> FindPackagesByCourierID(string courierId);

        IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID);

        IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail);

        void Update(Package model);
    }
}