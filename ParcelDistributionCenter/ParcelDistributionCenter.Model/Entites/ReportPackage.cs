using ParcelDistributionCenter.Model.Entites.BaseEntity;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model.Entites
{
    public class ReportPackage : Entity
    {
        public double AddingDurationInSeconds { get; set; }

        public PackageSize Size { get; set; }
    }
}