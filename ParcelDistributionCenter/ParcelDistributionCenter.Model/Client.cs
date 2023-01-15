using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    internal class Client:IPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public Client(string name, string address, string email, string phone) 
        {
            Name= name;
            Address= address;
            Email= email;
            Phone= phone;
        }

    }
}
