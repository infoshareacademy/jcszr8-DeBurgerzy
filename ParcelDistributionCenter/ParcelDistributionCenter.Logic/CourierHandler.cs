using ParcelDistributionCenter.Logic.Services;
using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Logic
{
    public class CourierHandler : ICourierHandler
    {
        private readonly IMemoryRepository _memoryRepository;
        private readonly IPackageServices _packageServices;

        public CourierHandler(IMemoryRepository memoryRepository, IPackageServices packageServices)
        {
            _memoryRepository = memoryRepository;
            _packageServices = packageServices;
        }
        public IEnumerable<Courier> FindAll() => _memoryRepository.CouriersList;

        public Courier FindById(string id) => _memoryRepository.CouriersList.FirstOrDefault(c => c.CourierId == id);
    
        public void Update(Courier model)
        {
            var courier = FindById(model.CourierId);
            courier.Name= model.Name;
            courier.Surname= model.Surname;
            courier.Email= model.Email;
            courier.Phone= model.Phone;
        }
        public void Delete(Courier model)
        {
            var courier = FindById(model.CourierId);
            _packageServices.UnassignCouriersPackages(courier.CourierId);
            _memoryRepository.CouriersList.Remove(courier);
        }
    }
}
