using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Logic
{
    public class PackageHandler
    {
        public static Package? FindPackageByNumber(int packageNumber)
        {
            return MemoryRepository.PackagesList.FirstOrDefault(Package => Package.PackageNumber == packageNumber);
        }

        public static IEnumerable<Package> FindPackageBySenderEmail(string senderEmail)
        {
            return MemoryRepository.PackagesList.Where(Package => Package.SenderEmail == senderEmail);
        }
    }
}
