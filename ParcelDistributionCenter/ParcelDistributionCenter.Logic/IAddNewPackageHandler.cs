using ParcelDistributionCenter.Logic.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IAddNewPackageHandler
    {
        bool AddNewPackage(PackageVM package);
    }
}