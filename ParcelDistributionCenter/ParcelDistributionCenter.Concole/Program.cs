using Newtonsoft.Json;
using ParcelDistributionCenter.Model;//dodane dzięki: add/Project Reference 
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // string ParcelUser = File.ReadAllText(@"D:\packages.json");//odczytanie json z pliku. Ścieżkę dodana na sztywno.
            //plik Json umieszczony w projekcie :jcszr8-DeBurgerzy\ParcelDistributionCenter\ParcelDistributionCenter.Concole\bin\Debug\net6.0
            string ParcelUser = File.ReadAllText("..\\..\\..\\..\\ParcelDistributionCenter.Model\\json\\packages.json");
            List<Parcel> UserList1 = JsonConvert.DeserializeObject<List<Parcel>>(ParcelUser);//wpisanie json do listy

            foreach (var item in UserList1)//testowe wyswietlanie listy użytkowników itp.
            {
                // Console.WriteLine($"Numer paczki: {item.Package_number}");
                Console.WriteLine($"Rozmiar paczki: {item.Size}");
                // Console.WriteLine($"Adres paczkomatu: {item.Delivery_machine_id}");
                // Console.WriteLine($"Adres dostawy: {item.Delivery_address}");
                //Console.WriteLine($"Data rejestracji: {item.Registered}");
                Console.WriteLine($"Data rejestracji: {item.Registered}");
                 Console.WriteLine("");
            }

            /*
            UserList1[0].Size = ParcelSize.Big;
            UserList1[1].Size = ParcelSize.Big;
            UserList1[2].Size = ParcelSize.Big;
            UserList1[3].Size = ParcelSize.Big;
            foreach (var item in UserList1)//testowe wyswietlanie listy użytkowników itp.
            {
                Console.WriteLine($"Rozmiar paczki: {item.Size}");
            }
            */
        }
    }
}