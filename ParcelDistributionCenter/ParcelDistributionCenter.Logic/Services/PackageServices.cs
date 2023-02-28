using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParcelDistributionCenter.Logic.Services
{
    public class PackageServices : IPackageServices
    {
        private readonly IMemoryRepository _memoryRepository;

        public PackageServices(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        public List<Package> GetCourierPackages(string courierId)
        {
            var packages = _memoryRepository.PackagesList.Where(p => p.CourierId == courierId).ToList();

            return packages;
        }

        public List<AssignPackagesVM> GetUnassignedPackages()
        {
            Courier unknownCourier = new Courier("Unassigned", "Unknown", "Unknown", "Unknown", "Unknown");
            var assignPackages = new List<AssignPackagesVM>();
            foreach (Package package in _memoryRepository.PackagesList)
            {
                List<string> CourisrsIds = _memoryRepository.CouriersList.Select(c=> c.CourierId).ToList();
                Courier courier = _memoryRepository.CouriersList.FirstOrDefault(c => c.CourierId == package.CourierId);
                if (courier == null)
                {
                    courier = unknownCourier;
                }
                assignPackages.Add(
                        new AssignPackagesVM(
                        courier.Email,
                        courier.Name,
                        courier.Surname,
                        courier.Phone,
                        package.PackageNumber,
                        package.Status,
                        package.Size,
                        package.SenderEmail,
                        package.RecipientEmail,
                        package.DeliveryAddress,
                        package.Registered
                        )
                );
            }
                return assignPackages;
        }
        public void AssignPackage(string packageNumber, string CourierId)
        {
            var package = _memoryRepository.PackagesList.First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = CourierId;

        }
        public void UnassignPackage(string packageNumber)
        {
            var package = _memoryRepository.PackagesList.First(p => p.PackageNumber == Int32.Parse(packageNumber));
            package.CourierId = "Unassigned";
        }
        public void UnassignCouriersPackages(string CourierId)
        {
            _memoryRepository.PackagesList.Where(p => p.CourierId == CourierId).Select(p => p.CourierId = "Unassigned");
        }
    }
}
