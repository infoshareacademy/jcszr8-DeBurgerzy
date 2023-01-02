using System;
using Newtonsoft.Json;
using ParcelDistributionCenter.Model;//dodane dzięki: add/Project Reference 

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ParcelUser = File.ReadAllText(@"D:\packages.json");//odczytanie json z pliku. Ścieżkę dodałem na sztywno na razie
            List<Parcel> UserList1 = JsonConvert.DeserializeObject<List<Parcel>>(ParcelUser);//wpisanie json do listy

            foreach (var item in UserList1)//testowe wyswietlanie listy użytkowników
            {
                Console.WriteLine(item.package_number);
            }
        }
    }
}