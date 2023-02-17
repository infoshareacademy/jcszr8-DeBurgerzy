using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public interface IMemoryRepository
    {
        static List<Courier> CouriersList { get; }
        static List<DeliveryMachine> DeliveryMachinesList { get; }
        static List<Package> PackagesList { get; }

        static void LoadData(){}
    }
}