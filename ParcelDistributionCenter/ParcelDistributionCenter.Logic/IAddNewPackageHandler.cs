using ParcelDistributionCenter.Logic.Models;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IAddNewPackageHandler
    {
        bool AddNewPackage(PackageVM packageVm, out Package? package);
    }
}