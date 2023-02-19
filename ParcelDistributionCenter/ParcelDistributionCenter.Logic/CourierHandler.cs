using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Logic
{
    public class CourierHandler : ICourierHandler
    {
        private readonly IMemoryRepository _memoryRepository;

        public CourierHandler(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }
        public IEnumerable<Courier> FindAll() => _memoryRepository.CouriersList;
    }
}
