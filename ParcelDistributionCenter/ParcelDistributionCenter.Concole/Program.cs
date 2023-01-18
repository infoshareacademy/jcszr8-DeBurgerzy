using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        private static bool highlight = true;
        private static void Main(string[] args)
        {
            OptionsHandler optionsHandler = new();
            MemoryRepository repo = new();
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                highlight = true;
                optionsHandler.ShowOptions();
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Enter: highlight = false; break;
                        case ConsoleKey.Escape: Environment.Exit(0); break;
                        case ConsoleKey.UpArrow: optionsHandler.MoveRowUp(); break;
                        case ConsoleKey.DownArrow: optionsHandler.MoveRowDown(); break;
                    }
                    optionsHandler.DrawSelectedRow(optionsHandler.SelectedIndex);
                } while (highlight);

                switch (optionsHandler.Options[optionsHandler.SelectedIndex].OptionType)
                {
                    case OptionsEnum.FindPackage:
                         //dodano do testowania
                         PackageForm.FindPackageByNumber();
                         Thread.Sleep(30000);
                         break;
                    case OptionsEnum.AddPackage :
                         PackageForm.AddPackage();
                        Thread.Sleep(30000);
                        break;
                    case OptionsEnum.EditPackageData: break;
                    case OptionsEnum.DisplayAllPackages:
                         PackageForm.DisplayAllPackages();
                         Thread.Sleep(30000);
                         break;
                }
            } while (true);
        }
    }
}