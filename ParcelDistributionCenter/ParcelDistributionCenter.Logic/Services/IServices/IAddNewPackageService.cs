using ParcelDistributionCenter.Logic.ViewModels;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IAddNewPackageService
    {
        PackageViewModel AddNewPackage(PackageViewModel package, DateTime packageAddingStartTime);
    }
}