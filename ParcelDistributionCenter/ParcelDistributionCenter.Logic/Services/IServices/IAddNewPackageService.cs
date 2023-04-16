using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IAddNewPackageService
    {
        bool AddNewPackage(ref Package package);
    }
}