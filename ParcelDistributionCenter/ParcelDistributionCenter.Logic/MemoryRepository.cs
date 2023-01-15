using Newtonsoft.Json;
using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class MemoryRepository
    {
        private const string clientsJsonName = "clients.json";
        private const string couriersJsonName = "couriers.json";
        private const string jsonFolderName = "json";
        private const string lockersJsonName = "lockers.json";
        private const string parcelsJsonName = "parcels.json";
        private static readonly string appDomainPath = AppDomain.CurrentDomain.BaseDirectory;

        // ZAPIS PLIKU MA BYĆ TYLKO DO STATYCZNEJ KLASY - NIE DO JSONA
        public MemoryRepository()
        {
            SetData();
        }

        public static List<Client> ClientsList { get; private set; }
        public static List<Courier> CouriersList { get; private set; }
        public static List<Locker> LockersList { get; private set; }
        public static List<Parcel> ParcelsList { get; private set; }

        private void SetData()
        {
            if (ClientsList != null)
            {
                return;
            }
            string clients = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, clientsJsonName));
            ClientsList = JsonConvert.DeserializeObject<List<Client>>(clients);

            string couriers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, couriersJsonName));
            CouriersList = JsonConvert.DeserializeObject<List<Courier>>(couriers);

            string lockers = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, lockersJsonName));
            LockersList = JsonConvert.DeserializeObject<List<Locker>>(lockers);

            string parcels = File.ReadAllText(Path.Combine(appDomainPath, jsonFolderName, parcelsJsonName));
            ParcelsList = JsonConvert.DeserializeObject<List<Parcel>>(parcels);
        }
    }
}