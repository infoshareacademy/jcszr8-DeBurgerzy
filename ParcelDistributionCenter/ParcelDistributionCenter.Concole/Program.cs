using ParcelDistributionCenter.Logic;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.ConsoleUI
{
    internal class Program
    {
        private static bool _highlight = true;

        private static void Main()
        {
            OptionsHandler optionsHandler = new();
            MemoryRepository repo = new();
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                _highlight = true;
                optionsHandler.ShowOptions();
                do
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Enter:
                            _highlight = false;
                            break;

                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;

                        case ConsoleKey.UpArrow:
                            optionsHandler.MoveRowUp();
                            break;

                        case ConsoleKey.DownArrow:
                            optionsHandler.MoveRowDown();
                            break;
                    }
                    optionsHandler.DrawSelectedRow(optionsHandler.SelectedIndex);
                } while (_highlight);

                switch (optionsHandler.Options[optionsHandler.SelectedIndex].OptionType)
                {
                    case OptionsEnum.FindPackageByNumber:
                        PackageForm.FindPackageByNumber();
                        Thread.Sleep(30000);
                        break;

                    case OptionsEnum.FindPackageByCourierID:
                        break;

                    case OptionsEnum.AddPackage:
                        //AddPackage.AddNewPackage();
                        break;

                    case OptionsEnum.EditPackageData:
                        break;

                    case OptionsEnum.DisplayAllPackages:
                        PackageForm.DisplayAllPackages();
                        Thread.Sleep(3000);
                        break;

                    case OptionsEnum.DisplayAllPackagesInPackageMachine:
                        break;
                }
            } while (true);
        }
    }
}