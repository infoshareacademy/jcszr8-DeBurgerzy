using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    internal interface IParcelHandler
    {
        public List<string> Parcels_numbers_list { get; set; }
    }
}
