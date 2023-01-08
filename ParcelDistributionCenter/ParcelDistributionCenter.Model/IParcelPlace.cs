using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    internal interface IParcelPlace
    {
        public string Id { get; init; }
        public string Address { get; init; }
        public bool Is_active { get; set; }
        public int Big_lockers_count { get; set; }
        public int Medium_lockers_count { get; set; }
        public int Small_lockers_count { get; set; }

    }
}
