using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;
using System.Drawing;

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

        public static IEnumerable<Package> FindAll() => MemoryRepository.PackagesList;

        private static IEnumerable<Package> ReturnPackages(Func<Package, bool> predicate)
        {
            IEnumerable<Package> packages = MemoryRepository.PackagesList.Where(predicate);
            if (!packages.Any())
            {
                return null;
            }
            return packages;
        }
        public static void Update(Package model)
        {
            var package = FindPackageByNumber(model.PackageNumber);
            package.Status = model.Status;
            package.CourierId = model.CourierId ;
            package.SenderName = model.SenderName ;
            package.RecipientName = model.RecipientName ;
            package.SenderEmail = model.SenderEmail ;
            package.SenderPhone = model.SenderPhone ;
            package.RecipientEmail = model.RecipientEmail ;
            package.RecipientPhone = model.RecipientPhone ;
            package.SenderAddress = model.SenderAddress ;
            package.DeliveryAddress = model.DeliveryAddress ;
            package.DeliveryMachineId = model.DeliveryMachineId ;
            package.Registered = model.Registered ;
        }
    }
}