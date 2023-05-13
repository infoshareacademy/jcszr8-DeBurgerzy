using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Entites.BaseEntity;
using ParcelDistributionCenter.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributionCenter.Model.Entites
{
    public class Package : Entity
    {
        // TODO: Think if nullable values are needed
        public Courier? Courier { get; set; }

        public string? CourierId { get; set; }

        [NotMapped]
        [JsonProperty("courier_id")]
        public string CourierJsonId { get; set; }

        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }

        // TODO: Think if nullable values are needed
        public DeliveryMachine? DeliveryMachine { get; set; }

        public string? DeliveryMachineId { get; set; }

        [NotMapped]
        [JsonProperty("delivery_machine_id")]
        public string DeliveryMachineJsonId { get; set; }

        [JsonProperty("package_number")]
        public int PackageNumber { get; set; }

        [JsonProperty("recipient_email")]
        public string RecipientEmail { get; set; }

        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }

        [JsonProperty("recipient_phone")]
        public string RecipientPhone { get; set; }

        public DateTime Registered { get; set; } = DateTime.Now;

        [JsonProperty("sender_address")]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_email")]
        public string SenderEmail { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        public PackageSize Size { get; set; }

        public Status Status { get; set; }
    }
}