using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Logic.Models
{
    public class PackageViewModel
    {
        private const string AddressErrorMessage = "Address should contain at least 1 digit, 2 letters and 1 space separator!";

        [Display(Name = "Delivery Address")]
        [Required(ErrorMessage = AddressErrorMessage)]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Recipient Email")]
        [EmailAddress]
        public string RecipientEmail { get; set; }

        [Display(Name = "Recipient Name and Surname/Company Name")]
        public string RecipientName { get; set; }

        // TODO: PORPAWIĆ TO REGULAR EXPRESSION
        [Display(Name = "Recipient Phone")]
        [Required(ErrorMessage = "A Recipient Phone is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Invalid Phone Number.")]
        public string RecipientPhone { get; set; }

        [Display(Name = "Sender Address")]
        [Required(ErrorMessage = AddressErrorMessage)]
        public string SenderAddress { get; set; }

        [Display(Name = "Sender Email")]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Display(Name = "Sender Name and Surname/Company Name")]
        public string SenderName { get; set; }

        // TODO: PORPAWIĆ TO REGULAR EXPRESSION
        [Display(Name = "Sender Phone")]
        [Required(ErrorMessage = "A Sender Phone is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Invalid Phone Number.")]
        public string SenderPhone { get; set; }

        [Display(Name = "Package Size")]
        [Required(ErrorMessage = "Package Size must be selected!")]
        public PackageSize Size { get; init; }

        [Display(Name = "Package Status")]
        [Required(ErrorMessage = "Package Status must be selected!")]
        public Status Status { get; set; }
    }
}