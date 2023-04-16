using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IPackageService
    {
        bool DeletePackageByNumber(int packageNumber);

        public Package FindPackageByPackageNumber(int packageNumber);

        IEnumerable<Package> GetAllPackages();

        public IEnumerable<int> GetAllPackagesNumber();

        bool Update(Package model);
    }
}