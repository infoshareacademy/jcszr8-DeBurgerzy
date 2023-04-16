using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Models.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributionCenter.Model.Models
{
    public class DeliveryMachine : Entity
    {
        [JsonProperty("address")]
        public string Address { get; init; }

        [JsonProperty("big_lockers_count")]
        public int BigLockersCount { get; set; }

        public Courier Courier { get; set; }

        [NotMapped]
        [JsonProperty("delivery_machine_id")]
        public string DeliveryMachineJsonId { get; init; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("medium_lockers_count")]
        public int MediumLockersCount { get; set; }

        public ICollection<Package> Packages { get; set; } = new List<Package>();

        [JsonProperty("small_lockers_count")]
        public int SmallLockersCount { get; set; }
    }
}