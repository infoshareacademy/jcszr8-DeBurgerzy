using ParcelDistributionCenter.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelDistributionCenter.Logic
{
    public class ClientHandler
    {
        public static void AddClient(List<Client> client_list, string email) 
        {
            var client = client_list.FirstOrDefault(Client => Client.Email == email);
            if (client != null)
            {
               Console.WriteLine("Klient o podanym emailu już istnieje");
            }
            else 
            {
                Console.WriteLine("Podaj swoje imie:");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj swoje nazwisko:");
                string surname = Console.ReadLine();
                Console.WriteLine("Podaj swój numer telefonu:");
                string phone = Console.ReadLine();
                Client c = new Client(name,surname, email,phone);
                client_list.Add(c);
                Console.Clear();
                Console.WriteLine("Dodano klienta!");
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void FindClientByEmail(List<Client> client_list, out Client? client)
        {
            client = null;
            int i = 0;
            while (i < 3)
            {
                Console.WriteLine("Podaj email:");
                string email = Console.ReadLine();
                client= client_list.FirstOrDefault(Client => Client.Email == email);
                if (client != null)
                {
                    Console.WriteLine("Znaleziono klienta!");
                    break;
                }
                i++;
                Console.WriteLine($"Nie znaleziono klienta o podanym mailu.\nWykorzystane próby:{i} z 3.\nWpisz ponownie poprawne dane.");
            }

        }

        public static void Display(Client client)
        {
            Console.WriteLine
                (
                  $" Email: {client.Email} || " +
                  $" Name: {client.Name} || " +
                  $" Surname: {client.Surname} || " +
                  $" Phone: {client.Phone}"
                );
        }

        public static void Display(List<Client> client_list) 
        {
            foreach(Client client in client_list) 
            {
                Display(client);
                Console.WriteLine("");
            }
        }
    }

}
