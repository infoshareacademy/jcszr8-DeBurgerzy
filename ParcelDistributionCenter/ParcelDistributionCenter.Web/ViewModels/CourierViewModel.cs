using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations;


namespace ParcelDistributionCenter.Web.ViewModels

{
    public class CourierViewModel
    {
        public string CourierId { get; init; }
        
        [Required(ErrorMessage = "Please enter Courier Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Courier Name")]
        [RegularExpression(@"[a-zA-Z]{3,12}", ErrorMessage = "The entered Name must be between 3 and 12 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Courier Surname")]
        [RegularExpression(@"[a-zA-Z]{3,12}", ErrorMessage = "The entered Surname must be between 3 and 12 letters")]
        public string Surname { get; set; }
    }
}