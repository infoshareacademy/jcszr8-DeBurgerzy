using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class PackageHandler
    {
        public static Package FindPackageByCourierID(string courierId)
        {
            Func<Package, bool> predicate = p => p.CourierId == courierId;
            return ReturnPackage(predicate);
        }

        public static Package FindPackageByNumber(int packageNumber)
        {
            Func<Package, bool> predicate = p => p.PackageNumber == packageNumber;
            return ReturnPackage(predicate);
        }

        public static Package FindPackageBySenderEmail(string senderEmail)
        {
            Func<Package, bool> predicate = p => p.SenderEmail == senderEmail;
            return ReturnPackage(predicate);
        }

        private static Package ReturnPackage(Func<Package, bool> predicate)
        {
            Package package = MemoryRepository.PackagesList.FirstOrDefault(predicate);
            if (package == default)
            {
                // dodać jakąś informację, że nie zwrócił obiektu
                return null;
            }
            return package;
        }
    }
}