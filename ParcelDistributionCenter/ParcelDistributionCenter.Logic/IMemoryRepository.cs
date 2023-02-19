using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IMemoryRepository
    {
        List<Courier> CouriersList { get; }
        List<DeliveryMachine> DeliveryMachinesList { get; }
        List<Package> PackagesList { get; }

        void LoadData();
    }
}