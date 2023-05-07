﻿using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Entites;

namespace ParcelDistributionCenter.Model.Context.JsonReader
{
    [Obsolete("WYWALIĆ Z KONTENERA I WRZUCIC DO KOSNTRUKTORA/METODY INITIALIZE SEEDA")]
    public class JsonReader : IJsonReader
    {
        private const string couriersJsonName = "couriers.json";
        private const string deliveryMachinesJsonName = "deliveryMachines.json";
        private const string jsonFolderName = "json";
        private const string packagesJsonName = "packages.json";
        private static readonly string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;

        public JsonReader(List<Courier> couriersList, List<DeliveryMachine> deliveryMachinesList, List<Package> packagesList)
        {
            CouriersList = couriersList;
            DeliveryMachinesList = deliveryMachinesList;
            PackagesList = packagesList;
        }

        public List<Courier> CouriersList { get; private set; }
        public List<DeliveryMachine> DeliveryMachinesList { get; private set; }
        public List<Package> PackagesList { get; private set; }

        public static JsonReader LoadData()
        {
            string couriers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, couriersJsonName));
            List<Courier> couriersList = JsonConvert.DeserializeObject<List<Courier>>(couriers);

            string lockers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, deliveryMachinesJsonName));
            List<DeliveryMachine> deliveryMachinesList = JsonConvert.DeserializeObject<List<DeliveryMachine>>(lockers);

            string parcels = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, packagesJsonName));
            List<Package> packagesList = JsonConvert.DeserializeObject<List<Package>>(parcels);

            return new JsonReader(couriersList, deliveryMachinesList, packagesList);
        }
    }
}