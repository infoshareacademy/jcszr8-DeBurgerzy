using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    public class Courier : IPerson, IParcelHandler
        
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set;}
        public string Phone { get; set;}
        public int Capacity { get; set; }
        public List<string> Rout { get; set; }
        public List<string> Parcels_numbers_list { get; set; }

        public Courier(string id, string name, string surname, string email, string phone, int capacity, List<string> rout, List<string> parcels_numbers_list)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone; 
            Capacity = capacity;
            Rout= rout; 
            Parcels_numbers_list = parcels_numbers_list;

        }
    }
}
