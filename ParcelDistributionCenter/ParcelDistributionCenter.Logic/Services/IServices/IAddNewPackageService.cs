using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IAddNewPackageService
    {
        bool AddNewPackage(ref Package package);
    }
}