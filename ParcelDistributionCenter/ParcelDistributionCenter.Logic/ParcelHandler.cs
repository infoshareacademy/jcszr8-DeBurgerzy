using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using ParcelDistributionCenter.Model;
using static System.Reflection.Metadata.BlobBuilder;


namespace ParcelDistributionCenter.Logic
{
    public static class ParcelHandler
    {
        public static void FindPackageByNumber (List<Model.Parcel>parcels_list, out Parcel? parcel) 
        {
            parcel= null;
            int i=0;
            while (i<3) 
            {
                Console.WriteLine("Podaj numer paczki:");
                string parcel_number = Console.ReadLine();
                    parcel = parcels_list.FirstOrDefault(Package => Package.Package_number == parcel_number);
                if (parcel != null)
                {
                    Console.WriteLine("Znaleziono paczkę o podanym numerze");
                    break;
                }
                i++;
                Console.WriteLine($"Nie znaleziono paczki o podanym numerze.\nWykorzystane próby:{i} z 3.\nWpisz ponownie poprawne dane.");
            }

        }

        public static void Display(Parcel parcel)
        {
            Console.WriteLine
                (
                  $" Numer: {parcel.Package_number}\n" +
                  $" Wielkość: {parcel.Size} \n" +
                  $" Mail Nadawcy: {parcel.Sender_email} \n" +
                  $" Mail Odbiorcy: {parcel.Recipient_email} \n" +
                  $" Paczkomat nadania: {parcel.Send_parcel_id} \n" +
                  $" Paczkomat docelowy: {parcel.Delivery_parcel_id} \n" +
                  $" Data nadania: {parcel.Registered}\n"
                );
        }
    }

}
