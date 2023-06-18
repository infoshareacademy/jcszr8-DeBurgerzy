using ParcelDistributionCenter.Model.Entites;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Logic.ViewModels
{
    public class DeliveryMachineViewModel
    {
        private const string AddressErrorMessage = "Please provide an address between 3 and 60 characters.";

        [Required]
        [RegularExpression(@"^[\p{L}0-9\s\.\-\/,\\]+ [\p{L}0-9\s\.\-\/,\\]+(, [\p{L}0-9\s\.\-\/,\\]+)?$", ErrorMessage = AddressErrorMessage)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Big Lockers Count is required.")]
        [Display(Name = "Big Lockers Count")]
        public int BigLockersCount { get; set; }

        public Courier? Courier { get; set; }

        public string? Id { get; set; }

        [Display(Name = "Activity")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Medium Lockers Count is required.")]
        [Display(Name = "Medium Lockers Count")]
        public int MediumLockersCount { get; set; }

        public ICollection<Package>? Packages { get; set; }

        [Required(ErrorMessage = "Small Lockers Count is required.")]
        [Display(Name = "Small Lockers Count")]
        public int SmallLockersCount { get; set; }
    }
}