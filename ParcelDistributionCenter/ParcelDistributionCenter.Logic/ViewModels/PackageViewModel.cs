using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Logic.ViewModels
{
    public class PackageViewModel
    {
        private const string AddressErrorMessage = "Please provide an address between 3 and 60 characters.";

        [Display(Name = "Delivery Address")]
        [RegularExpression(@"^[\p{L}0-9\s\.\-\/,\\]+ [\p{L}0-9\s\.\-\/,\\]+(, [\p{L}0-9\s\.\-\/,\\]+)?$", ErrorMessage = AddressErrorMessage)]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Package Number")]
        public int PackageNumber { get; set; }

        [Display(Name = "Recipient Email")]
        [EmailAddress]
        public string RecipientEmail { get; set; }

        [Display(Name = "Recipient Name and Surname/Company Name")]
        [RegularExpression(@"[a-zA-Z0-9\s\-]{3,20}", ErrorMessage = "The entered Name must be between 3 and 20 characters")]
        public string RecipientName { get; set; }

        [Display(Name = "Recipient Phone")]
        [Required(ErrorMessage = "A Recipient Phone is required.")]
        [RegularExpression(@"^[\+]?[0-9]{2}[-\s\.]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3,4}$", ErrorMessage = "Please provide number in format +NN NNN-NNN-NNN")]
        public string RecipientPhone { get; set; }

        [Display(Name = "Package Registration Date")]
        public DateTime Registered { get; set; } = DateTime.Now;

        [Display(Name = "Sender Address")]
        [RegularExpression(@"^[\p{L}0-9\s\.\-\/,\\]+ [\p{L}0-9\s\.\-\/,\\]+(, [\p{L}0-9\s\.\-\/,\\]+)?$", ErrorMessage = AddressErrorMessage)]
        public string SenderAddress { get; set; }

        [Display(Name = "Sender Email")]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Display(Name = "Sender Name and Surname/Company Name")]
        [RegularExpression(@"[a-zA-Z0-9,\s\-]{3,20}", ErrorMessage = "The entered Name must be between 3 and 20 characters")]
        public string SenderName { get; set; }

        [Display(Name = "Sender Phone")]
        [Required(ErrorMessage = "A Sender Phone is required.")]
        [RegularExpression(@"^[\+]?[0-9]{2}[-\s\.]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3,4}$", ErrorMessage = "Please provide number in format +NN NNN-NNN-NNN")]
        public string SenderPhone { get; set; }

        [Display(Name = "Package Size")]
        [Required(ErrorMessage = "Package Size must be selected!")]
        public PackageSize Size { get; init; }

        [Display(Name = "Package Status")]
        [Required(ErrorMessage = "Package Status must be selected!")]
        public Status Status { get; set; }
    }
}