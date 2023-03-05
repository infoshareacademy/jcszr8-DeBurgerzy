using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.Model.Models
{
    public class Package
    {
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
        {
        }

        [JsonProperty("courier_id")]
        public string CourierId { get; set; }

        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }

        [JsonProperty("delivery_machine_id")]
        public string DeliveryMachineId { get; set; }

        [JsonProperty("package_number")]
        public int PackageNumber { get; init; }

        [JsonProperty("recipient_email")]
        public string RecipientEmail { get; set; }

        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }

        [JsonProperty("recipient_phone")]
        public string RecipientPhone { get; set; }

        public DateTime Registered { get; set; }

        [JsonProperty("sender_address")]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_email")]
        public string SenderEmail { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        public PackageSize Size { get; init; }

        public Status Status { get; set; }
    }
}