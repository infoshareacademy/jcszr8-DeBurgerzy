using Newtonsoft.Json;
using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model;//dodane dzięki: add/Project Reference 
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load Clients
            string clients = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\clients.json");
            List<Client> clients_list = JsonConvert.DeserializeObject<List<Client>>(clients);

            //Load Couriers
            string couriers = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\couriers.json");
            List<Courier> couriers_list = JsonConvert.DeserializeObject<List<Courier>>(couriers);

            //Load Parcel Lockers
            string lockers = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\lockers.json");
            List<Courier> lockers_list = JsonConvert.DeserializeObject<List<Courier>>(lockers);

            //Load Parcels
            string parcels = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\parcels.json");
            List<Parcel> parcels_list = JsonConvert.DeserializeObject<List<Parcel>>(parcels);


            //Test
            ParcelHandler.Display(parcels_list);

            /*
            //TEST DZIAŁANIA WYSZUKIWANIA
            ParcelHandler.FindPackageByNumber(UserList1, out Parcel? parcel);

            if(parcel==null)
            {
                Console.WriteLine("Nie udało się znaleźć paczki.");
            }
            else 
            {
                ParcelHandler.Display(parcel);
            }  
            */
        }
    }
}