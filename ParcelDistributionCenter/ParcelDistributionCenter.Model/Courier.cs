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
        public string Email { get; set;}
        public string Phone { get; set;}
        public int Capacity { get; set; }
        public List<string> Rout_places_ids { get; set; }
        public List<uint> Parcels_numbers_list { get; set; }

        public Courier(string name, string address, string email, string phone, int capacity)
        {
            Id = "a1"; // do opracowania auto nadawanie GUID
            Name = name;
            Email = email;
            Phone = phone; 
            Capacity = capacity;
            Rout_places_ids = new List<string>();
            Parcels_numbers_list = new List<uint>();
        }
    }
}
