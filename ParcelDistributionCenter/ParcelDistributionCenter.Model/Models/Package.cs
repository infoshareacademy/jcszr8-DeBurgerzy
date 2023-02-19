﻿using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributionCenter.Model.Models
{
    public class Package
    {
        private const string AddressErrorMessage = "Address should contain at least 1 digit, 2 letters and 1 space separator!";

        public Package(int packageNumber, Status status, string courierId, string senderName, string recipientName, PackageSize size, string senderEmail, string senderPhone,
            string recipientEmail, string recipientPhone, string senderAddress, string deliveryAddress, string deliveryMacineId, DateTime registered)
        {
            PackageNumber = packageNumber;
            Status = status;
            CourierId = courierId;
            SenderName = senderName;
            RecipientName = recipientName;
            Size = size;
            SenderEmail = senderEmail;
            SenderPhone = senderPhone;
            RecipientEmail = recipientEmail;
            RecipientPhone = recipientPhone;
            SenderAddress = senderAddress;
            DeliveryAddress = deliveryAddress;
            DeliveryMachineId = deliveryMacineId;
            Registered = registered;
        }

        public Package()
        { }

        [JsonProperty("courier_id")]
        [Display(Name = "Courier Id")]
        public string CourierId { get; set; }

        [JsonProperty("delivery_address")]
        [Display(Name = "Delivery Address")]
        [Required(ErrorMessage = AddressErrorMessage)]
        public string DeliveryAddress { get; set; }

        [JsonProperty("delivery_machine_id")]
        [Display(Name = "Delivery Machine Id")]
        public string DeliveryMachineId { get; set; }

        [JsonProperty("package_number")]
        [Display(Name = "Package Number")]
        public int PackageNumber { get; init; }

        [JsonProperty("recipient_email")]
        [Display(Name = "Recipient Email")]
        [EmailAddress]
        public string RecipientEmail { get; set; }

        [JsonProperty("recipient_name")]
        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }

        [JsonProperty("recipient_phone")]
        [Display(Name = "Recipient Phone")]
        [Phone]
        public string RecipientPhone { get; set; }

        [Display(Name = "Registration date")]
        public DateTime Registered { get; set; }

        [JsonProperty("sender_address")]
        [Display(Name = "Sender Address")]
        [Required(ErrorMessage = AddressErrorMessage)]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_email")]
        [Display(Name = "Sender Email")]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [JsonProperty("sender_name")]
        [Display(Name = "Sender Name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_phone")]
        [Display(Name = "Sender Phone")]
        [Phone]
        public string SenderPhone { get; set; }

        [Display(Name = "Package Size")]
        public PackageSize Size { get; init; }

        public Status Status { get; set; }
    }
}