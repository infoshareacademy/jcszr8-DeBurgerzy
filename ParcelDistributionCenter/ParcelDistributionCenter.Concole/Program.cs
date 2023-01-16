using ParcelDistributionCenter.Logic;

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TEST DZIAŁANIA WYSZUKIWANIA PACZEK
            MemoryRepository repo = new();
            PackageForm.FindPackageByNumber();
        }
    }
}