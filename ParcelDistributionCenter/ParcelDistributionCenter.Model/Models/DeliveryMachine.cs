using Newtonsoft.Json;

namespace ParcelDistributionCenter.Model.Models
{
    public class DeliveryMachine
    {
        public DeliveryMachine(string deliveryMachineId, string address, bool isActive, int bigLockersCount, int mediumLockersCount, int smallLockersCount)
        {
            DeliveryMachineId = deliveryMachineId;
            Address = address;
            IsActive = isActive;
            BigLockersCount = bigLockersCount;
            MediumLockersCount = mediumLockersCount;
            SmallLockersCount = smallLockersCount;
        }

        [JsonProperty("address")]
        public string Address { get; init; }

        [JsonProperty("big_lockers_count")]
        public int BigLockersCount { get; set; }

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