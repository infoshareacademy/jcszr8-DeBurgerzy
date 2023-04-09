using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Model.Context.Memory
{
    public interface IMemoryRepository
    {
        List<Courier> CouriersList { get; }
        List<DeliveryMachine> DeliveryMachinesList { get; }
        List<Package> PackagesList { get; }
    }
}