using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageService
    {
        IEnumerable<Package> GetAllPackages();
        public Package FindPackageByPackageNumber(int packageNumber);
       
        /*bool DeletePackageByNumber(string packageNumber);

        IEnumerable<Package> FindPackagesByCourierID(string courierId);

        IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID);

        IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail);


        void Update(Package model);
        */
    }
}