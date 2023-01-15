using ParcelDistributionCenter.Model.Interfaces;

namespace ParcelDistributionCenter.Model.Models
{
    public class Client : IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Client(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }
    }
}