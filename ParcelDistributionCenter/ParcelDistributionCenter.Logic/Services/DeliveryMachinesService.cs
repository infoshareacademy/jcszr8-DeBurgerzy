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

        public void CreateNewDeliveryMachine(DeliveryMachine deliveryMachine)
        {
            string deliveryMachineID = AssignDeliveryMachineID();
            DeliveryMachine newDeliveryMachine = new DeliveryMachine(deliveryMachineID, deliveryMachine.Address, deliveryMachine.IsActive, deliveryMachine.BigLockersCount,
                deliveryMachine.MediumLockersCount, deliveryMachine.SmallLockersCount);
            _memoryRepository.DeliveryMachinesList.Add(newDeliveryMachine);
        }

        public bool DeleteDeliveryMachineById(string deliveryMachineId)
        {
            DeliveryMachine deliveryMachine = FindDeliveryMachineById(deliveryMachineId);
            if (deliveryMachine != null)
            {
                _memoryRepository.DeliveryMachinesList.Remove(deliveryMachine);
                return true;
            }
            return false;
        }

        public IEnumerable<DeliveryMachine> GetAll() => _memoryRepository.DeliveryMachinesList;

        private string AssignDeliveryMachineID()
        {
            IEnumerable<string> deliveryMachineIDs = _memoryRepository.DeliveryMachinesList.Select(c => c.DeliveryMachineId);
            return GenerateRandomID(deliveryMachineIDs);
        }

        private DeliveryMachine FindDeliveryMachineById(string deliveryMachineId)
        {
            DeliveryMachine package = _memoryRepository.DeliveryMachinesList.FirstOrDefault(p => p.DeliveryMachineId == deliveryMachineId);
            if (package == default)
            {
                return null;
            }
            return package;
        }

        private string GenerateRandomID(IEnumerable<string> IdCollection)
        {
            Random rnd = new();
            int selectedIndex = rnd.Next(IdCollection.Count());
            return IdCollection.ToArray()[selectedIndex];
        }
    }
}