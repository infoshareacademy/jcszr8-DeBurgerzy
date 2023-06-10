using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model.DTOs
{
    // Czy to jest w ogóle potrzebne?
    public class ReportPackageDto
    {
        public TimeSpan Duration { get; set; }
        public PackageSize Size { get; set; }
    }
}