using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Enums;
using ParcelDistributionCenter.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ParcelDistributionCenter.Web.Models
{

    public class AssignPackagesVM
    {
        public AssignPackagesVM(string email, string name, string surname, string phone, int packageNumber, Status status, PackageSize size, string senderEmail,
           string recipientEmail, string deliveryAddress, DateTime registered)
        {
            Email = email;
            Name = name;
            Surname = surname; 
            Phone = phone;
            PackageNumber = packageNumber;
            Status = status;
            Size = size;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
            DeliveryAddress = deliveryAddress;
            Registered = registered;
        }


        public string Email { get; set; }
        [Display(Name = "Courier Name")]
        public string Name { get; set; }
        [Display(Name = "Courier Phone")]
        public string Phone { get; set; }
        [Display(Name = "Courier Surname")]
        public string Surname { get; set; }

        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Package Number")]
        public int PackageNumber { get; init; }

        [Display(Name = "Recipient Email")]
        [EmailAddress]
        public string RecipientEmail { get; set; }

        [Display(Name = "Registration date")]
        public DateTime Registered { get; set; }

        [Display(Name = "Sender Email")]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Display(Name = "Package Size")]
        public PackageSize Size { get; init; }

        public Status Status { get; set; }
    }
}