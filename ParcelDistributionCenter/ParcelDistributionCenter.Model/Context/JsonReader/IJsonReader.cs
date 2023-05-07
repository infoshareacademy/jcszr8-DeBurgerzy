using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context.JsonReader
{
    public interface IJsonReader
    {
        List<Courier> CouriersList { get; }
        List<DeliveryMachine> DeliveryMachinesList { get; }
        List<Package> PackagesList { get; }
    }
}