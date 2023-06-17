using ParcelDistributionCenter.Model.Entites;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IReportService
    {
        Task AddPackageCreatingDuration(DateTime packageAddingStartTime, DateTime packageAddingEndTime, PackageSize size);

        Task<IEnumerable<ReportPackage>> GetReportPackages();
    }
}