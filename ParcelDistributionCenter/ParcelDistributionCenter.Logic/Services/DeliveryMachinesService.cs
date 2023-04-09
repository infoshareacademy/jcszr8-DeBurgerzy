using ParcelDistributionCenter.Logic.Services.IServices;
using ParcelDistributionCenter.Model.Models;
using ParcelDistributionCenter.Model.Repositories;

namespace ParcelDistributionCenter.Logic.Services
{
    // TODO: Prevent code from nullable ids coming form json
    public class DeliveryMachinesService : IDeliveryMachinesService
    {
        private readonly IRepository<DeliveryMachine> _repository;

        public DeliveryMachinesService(IRepository<DeliveryMachine> repository)
        {
            _repository = repository;
        }

        public void CreateNewDeliveryMachine(DeliveryMachine deliveryMachine) => _repository.Insert(deliveryMachine);

        public bool DeleteDeliveryMachineById(string deliveryMachineId)
        {
            DeliveryMachine deliveryMachine = FindDeliveryMachineById(deliveryMachineId);
            if (deliveryMachine != null)
            {
                _repository.Delete(deliveryMachine);
                return true;
            }
            return false;
        }

        public IEnumerable<DeliveryMachine> GetAll() => _repository.GetAll();

        private DeliveryMachine FindDeliveryMachineById(string deliveryMachineId)
        {
            DeliveryMachine deliveryMachine = _repository.Get(deliveryMachineId);
            if (deliveryMachine == default)
            {
                return null;
            }
            return deliveryMachine;
        }
    }
}