using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context.JsonReaderService
{
    public class JsonReader : IJsonReader
    {
        private const string couriersJsonName = "couriers.json";
        private const string deliveryMachinesJsonName = "deliveryMachines.json";
        private const string jsonFolderName = "json";
        private const string packagesJsonName = "packages.json";
        private static readonly string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;

        public List<Courier> CouriersList { get; private set; } = new List<Courier>();
        public List<DeliveryMachine> DeliveryMachinesList { get; private set; } = new List<DeliveryMachine>();
        public List<Package> PackagesList { get; private set; } = new List<Package>();

        public void LoadData()
        {
            string couriers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, couriersJsonName));
            CouriersList = JsonConvert.DeserializeObject<List<Courier>>(couriers);

            string lockers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, deliveryMachinesJsonName));
            DeliveryMachinesList = JsonConvert.DeserializeObject<List<DeliveryMachine>>(lockers);

            string parcels = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, packagesJsonName));
            PackagesList = JsonConvert.DeserializeObject<List<Package>>(parcels);
        }
    }
}