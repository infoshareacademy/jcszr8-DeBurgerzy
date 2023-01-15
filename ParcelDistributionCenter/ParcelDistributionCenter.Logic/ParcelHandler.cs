using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using ParcelDistributionCenter.Model.Models;
using static System.Reflection.Metadata.BlobBuilder;


namespace ParcelDistributionCenter.Logic
{
    public static class ParcelHandler
    {
        public static void SendPackage()
        {
            //Dane nadawcy
            //Wielkość paczki;
            //Paczkomat z którego wysyłam
            //Dane odbiorcy
            //Paczkomat do którego wysyłam
        }
        public static void FindPackageByNumber (List<Parcel>parcels_list, out Parcel? parcel) 
        {
            parcel= null;
            int i=0;
            while (i<3) 
            {
                Console.WriteLine("Podaj numer paczki:");
                string number = Console.ReadLine();
                    parcel = parcels_list.FirstOrDefault(Package => Package.Number == number);
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
                  $" Numer: {parcel.Number}\n" +
                  $" Wielkość: {parcel.Size} \n" +
                  $" Mail Nadawcy: {parcel.SenderEmail} \n" +
                  $" Mail Odbiorcy: {parcel.Recipient_email} \n" +
                  $" Paczkomat nadania: {parcel.SenderLockerId} \n" +
                  $" Paczkomat docelowy: {parcel.Delivery_locker_id} \n" +
                  $" Data nadania: {parcel.Registered}\n"
                );
        }

        public static void Display(List<Parcel> parcels)
        {
            foreach (Parcel courier in parcels)
            {
                Display(courier);
            }
        }
    }

}
