using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Model
{
    public enum Status
    {
        in_preparation,
        in_delivery,
        stored_in_machine,
        stored_by_sender,
        delivered,
    }
}
