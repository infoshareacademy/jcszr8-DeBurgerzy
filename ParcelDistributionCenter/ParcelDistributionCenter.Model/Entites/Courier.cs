using Newtonsoft.Json;

namespace ParcelDistributionCenter.Model.Models
{
    public class Courier
    { 
        [JsonConstructor]
        public Courier(string courierId, string name, string surname, string email, string phone)
        {
            CourierId = courierId;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public Courier(string name, string surname, string email, string phone)
        {
            CourierId = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public Courier() { }

        [JsonProperty("courier_id")]
        public string CourierId { get; init; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}