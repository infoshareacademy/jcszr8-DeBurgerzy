using ParcelDistributionCenter.Model.Interfaces;

namespace ParcelDistributionCenter.Model.Models
{
    public class Client : IPerson
    {
        public Client(string name, string surname, string email, string phone)
        {
            CheckValidation(name, surname, email, phone);
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }

        private void CheckIfNullOrEmpty(string value, string variableName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(variableName);
            }
        }

        private void CheckValidation(string name, string surname, string email, string phone)
        {
            CheckIfNullOrEmpty(name, nameof(name));
            CheckIfNullOrEmpty(surname, nameof(surname));
            CheckIfNullOrEmpty(email, nameof(email));
            CheckIfNullOrEmpty(phone, nameof(phone));
        }
    }
}