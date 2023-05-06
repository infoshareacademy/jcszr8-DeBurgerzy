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
        [RegularExpression(@"^[\+]?[0-9]{2}[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3}$", ErrorMessage = "Please provide number in format +NN NNN-NNN-NNN")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Courier Surname")]
        [RegularExpression(@"[a-zA-Z]{3,12}", ErrorMessage = "The entered Surname must be between 3 and 12 letters")]
        public string Surname { get; set; }
    }
}