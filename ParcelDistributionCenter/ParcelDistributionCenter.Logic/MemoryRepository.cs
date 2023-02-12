﻿using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class MemoryRepository : IMemoryRepository
    {
        private const string couriersJsonName = "couriers.json";
        private const string deliveryMachinesJsonName = "deliveryMachines.json";
        private const string jsonFolderName = "json";
        private const string packagesJsonName = "packages.json";
        private readonly string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;

        public List<Courier> CouriersList { get; private set; }
        public List<DeliveryMachine> DeliveryMachinesList { get; private set; }
        public List<Package> PackagesList { get; private set; }

        public void LoadData()
        {
            if (PackagesList != null)
            {
                return;
            }
            string couriers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, couriersJsonName));
            CouriersList = JsonConvert.DeserializeObject<List<Courier>>(couriers);

            string lockers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, deliveryMachinesJsonName));
            DeliveryMachinesList = JsonConvert.DeserializeObject<List<DeliveryMachine>>(lockers);

            string parcels = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, packagesJsonName));
            PackagesList = JsonConvert.DeserializeObject<List<Package>>(parcels);
        }
    }
}