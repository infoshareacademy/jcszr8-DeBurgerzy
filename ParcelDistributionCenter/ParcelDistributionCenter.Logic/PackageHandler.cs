using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class PackageHandler
    {
        public static Package FindPackageByNumber(int packageNumber)
        {
            Package package = MemoryRepository.PackagesList.FirstOrDefault(p => p.PackageNumber == packageNumber);
            if (package == default)
            {
                return null;
            }
            return package;
        }

        public static IEnumerable<Package> FindPackagesByCourierID(string courierId) => ReturnPackages(p => p.CourierId == courierId);

        public static IEnumerable<Package> FindPackagesByDeliveryMachineID(string deliveryMachineID) => ReturnPackages(p => p.DeliveryMachineId == deliveryMachineID);

        public static IEnumerable<Package> FindPackagesBySenderEmail(string senderEmail) => ReturnPackages(p => p.SenderEmail == senderEmail);

        private static IEnumerable<Package> ReturnPackages(Func<Package, bool> predicate)
        {
            IEnumerable<Package> packages = MemoryRepository.PackagesList.Where(predicate);
            if (!packages.Any())
            {
                return null;
            }
            return packages;
        }
    }
}