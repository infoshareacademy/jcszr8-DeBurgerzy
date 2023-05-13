using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Logic.Services.IServices
{
    public interface IDeliveryMachinesService
    {
        void CreateNewDeliveryMachine(DeliveryMachine deliveryMachine);

        bool DeleteDeliveryMachineById(string deliveryMachineId);

        IEnumerable<DeliveryMachine> GetAll();

        DeliveryMachine GetDeliveryMachineById(string id);

        IEnumerable<Package> GetDeliveryMachinePackages(string deliveryMachineId);

        IEnumerable<Package> GetDeliveryMachineUnassignedPackages();

        void UnassignPackage(string packageNumber, string deliveryMachineId);

        void UpdateDeliveryMachine(DeliveryMachine deliveryMachine);
    }
}