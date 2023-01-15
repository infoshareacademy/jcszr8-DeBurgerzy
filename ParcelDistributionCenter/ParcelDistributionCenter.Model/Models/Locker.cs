using ParcelDistributionCenter.Model.Interfaces;

namespace ParcelDistributionCenter.Model.Models
{
    internal class Locker : IParcelHandler, IParcelPlace
    {
        public Locker(string id, string address, int big_lockers_count, int medium_lockers_count, int small_lockers_count) // konstruktor przy starcie programu - wczytywanie z bazy
        {
            Id = id;
            Address = address;
            Is_active = true;
            Big_lockers_count = big_lockers_count;
            Medium_lockers_count = medium_lockers_count;
            Small_lockers_count = small_lockers_count;
            Parcels_numbers_list = new List<string>();
        }

        //public Dictionary<Enums.ParcelSize, int> Capacity; - alternatywa dla 3 pól z wielkościami paczek
        public Locker(string address, int big_lockers_count, int medium_lockers_count, int small_lockers_count) //konstruktor przy tworzeniu nowej
        {
            Id = "P1";// do opracowania auto nadawanie GUID
            Address = address;
            Is_active = true;
            Big_lockers_count = big_lockers_count;
            Medium_lockers_count = medium_lockers_count;
            Small_lockers_count = small_lockers_count;
            Parcels_numbers_list = new List<string>();
        }

        public string Address { get; init; }
        public int Big_lockers_count { get; set; }
        public string Id { get; init; }
        public bool Is_active { get; set; }
        public int Medium_lockers_count { get; set; }
        public List<string> Parcels_numbers_list { get; set; }
        public int Small_lockers_count { get; set; }
    }
}