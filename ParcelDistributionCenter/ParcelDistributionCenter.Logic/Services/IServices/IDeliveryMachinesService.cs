using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IDeliveryMachinesService
    {
        void CreateNewDeliveryMachine(DeliveryMachine deliveryMachine);

        bool DeleteDeliveryMachineById(string deliveryMachineId);

        IEnumerable<DeliveryMachine> GetAll();
    }
}