using Newtonsoft.Json;


namespace ParcelDistributionCenter.Model.Models
{
    public class Courier
        
    {
        public Courier(string courierId, string name, string surname, string email, string phone )
        {
            CourierId = courierId;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        [JsonProperty("courier_id")]
        public string CourierId { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}