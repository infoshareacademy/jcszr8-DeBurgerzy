using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Model.DTOs
{
    public class ReportPackageDto
    {
        [Display(Name = "Adding Duration In Seconds")]
        public double AddingDurationInSeconds { get; set; }

        public PackageSize Size { get; set; }

        [Display(Name = "Time Created")]
        public DateTime TimeCreated { get; set; }
    }
}