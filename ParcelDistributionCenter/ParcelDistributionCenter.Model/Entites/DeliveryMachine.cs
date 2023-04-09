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

        [NotMapped]
        [JsonProperty("delivery_machine_id")]
        public string DeliveryMachineId { get; init; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("medium_lockers_count")]
        public int MediumLockersCount { get; set; }

        [JsonProperty("small_lockers_count")]
        public int SmallLockersCount { get; set; }
    }
}