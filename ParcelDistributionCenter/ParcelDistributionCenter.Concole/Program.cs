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
            string ParcelUser = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\generated.json");
            List<Parcel> UserList1 = JsonConvert.DeserializeObject<List<Parcel>>(ParcelUser);

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
        }
    }
}