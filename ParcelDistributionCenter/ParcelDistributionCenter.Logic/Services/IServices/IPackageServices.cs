using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Web.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageServices
    {
        public void AssignPackage(string id, string packageNumber) { }

        public void UnassignCouriersPackages(string CourierId) { }

        public void UnassignPackage(string packageNumber) { }
    }
}