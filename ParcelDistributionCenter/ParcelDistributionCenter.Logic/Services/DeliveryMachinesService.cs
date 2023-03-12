using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services
{
    public class DeliveryMachinesService : IDeliveryMachinesService
    {
        private readonly IMemoryRepository _memoryRepository;

        public DeliveryMachinesService(IMemoryRepository memoryRepository)
        {
            _memoryRepository = memoryRepository;
        }

        public IEnumerable<DeliveryMachine> GetAll() => _memoryRepository.DeliveryMachinesList;
    }
}