using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Models.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributionCenter.Model.Models
{
    public class Courier : Entity
    {
        [Obsolete("Get rid of contructor")]
        [JsonConstructor]
        public Courier(string courierId, string name, string surname, string email, string phone)
        {
            CourierJsonId = courierId;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        [Obsolete("Get rid of contructor")]
        public Courier(string name, string surname, string email, string phone)
        {
            CourierJsonId = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public Courier()
        { }

        [NotMapped]
        [JsonProperty("courier_id")]
        public string CourierJsonId { get; init; }

        // TODO: Think if nullable values are needed
        [NotMapped]
        public DeliveryMachine? DeliveryMachine { get; set; }

        // TODO: Think if nullable values are needed
        [NotMapped]
        public string? DeliveryMachineId { get; set; }

        [JsonProperty("email")]
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