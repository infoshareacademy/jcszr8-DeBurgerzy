using ParcelDistributionCenter.Model.Models;

namespace ParcelDistributionCenter.Logic
{
    public class ClientHandler
    {
        public static void AddClient(List<Client> client_list, string email)
        {
            Client? client = client_list.FirstOrDefault(Client => Client.Email == email);
            if (client != null)
            {
                Console.WriteLine("Client by given email already exists!");
            }
            else
            {
                string name = string.Empty;
                while (string.IsNullOrEmpty(name))
                {
                    Console.Write("Give your name: ");
                    name = Console.ReadLine(); // dodanie walidacji Name -> w osobnej klasie
                }
                Console.Write("Give your surname: ");
                string surname = Console.ReadLine();
                Console.Write("Give your telephone number: ");
                string phone = Console.ReadLine();
                Client c = new(name, surname, email, phone);
                client_list.Add(c);
                Console.Clear();
                Console.WriteLine("Client added!");
            }
            Console.ReadKey();
            Console.Clear();
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
            foreach (Client client in client_list)
            {
                Display(client);
                Console.WriteLine("");
            }
        }

        public static void FindClientByEmail(List<Client> client_list, out Client? client)
        {
            client = null;
            int i = 0;
            while (i < 3)
            {
                Console.WriteLine("Podaj email:");
                string email = Console.ReadLine();
                client = client_list.FirstOrDefault(Client => Client.Email == email);
                if (client != null)
                {
                    Console.WriteLine("Znaleziono klienta!");
                    break;
                }
                i++;
                Console.WriteLine($"Nie znaleziono klienta o podanym mailu.\nWykorzystane próby:{i} z 3.\nWpisz ponownie poprawne dane.");
            }
        }
    }
}