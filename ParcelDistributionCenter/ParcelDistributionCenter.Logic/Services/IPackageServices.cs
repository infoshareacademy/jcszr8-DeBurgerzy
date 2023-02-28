using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public interface IPackageServices
    {
        List<Package> GetCourierPackages(string courierId);
        List<AssignPackagesVM> GetUnassignedPackages();
        public void AssignPackage(string id, string packageNumber) { }
        public void UnassignPackage(string packageNumber){ }
        public void UnassignCouriersPackages(string CourierId) { }

    }

}