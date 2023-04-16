using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Entites.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributionCenter.Model.Entites
{
    public class Courier : Entity
    {
        [NotMapped]
        [JsonProperty("courier_id")]
        public string CourierJsonId { get; init; }

        // TODO: Think if nullable values are needed
        public DeliveryMachine? DeliveryMachine { get; set; }

        // TODO: Think if nullable values are needed
        public string? DeliveryMachineId { get; set; }

        [JsonProperty("email")]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public ICollection<Package> Packages { get; set; } = new List<Package>();

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}