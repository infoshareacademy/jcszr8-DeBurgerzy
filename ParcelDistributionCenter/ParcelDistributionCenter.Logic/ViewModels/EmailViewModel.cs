using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Logic.ViewModels
{
    public class EmailViewModel
    {
        [Required]
        [Range(0, 23, ErrorMessage = "The hour must be between 0 and 23.")]
        public int HourToSendEmail { get; set; }
    }
}