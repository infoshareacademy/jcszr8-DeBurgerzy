using ParcelDistributionCenter.ConsoleUI.Options;
using ParcelDistributionCenter.Model.Enums;

namespace ParcelDistributionCenter.ConsoleUI;

public class OptionsHandler
{
    private int _cursorLeft;
    private int _cursorTop;
    private bool _firstTimeSelected = false;
    private int _initialCursorLeft;
    private int _initialCursorTop;
    private int _optionsLastIndex;
    public List<Option> Options { get; private set; } = new();
    public int SelectedIndex { get; private set; }

    public void DrawSelectedRow(int selectedIndex)
    {
        _cursorTop = _initialCursorTop;
        _cursorLeft = _initialCursorLeft;
        if (selectedIndex != -1)
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.SetCursorPosition(_cursorLeft, _cursorTop + i);
                var backgroundColor = selectedIndex == i ? Console.BackgroundColor = ConsoleColor.DarkCyan : ConsoleColor.Black;
                Console.BackgroundColor = backgroundColor;
                Console.WriteLine(Options[i].Statement);
            }
        }
    }

    public void MoveRowDown()
    {
        if (!_firstTimeSelected)
        {
            SelectedIndex = 0;
            _firstTimeSelected = true;
        }
        else
        {
            if (SelectedIndex < _optionsLastIndex)
            {
                SelectedIndex += 1;
            }
        }
    }

    public void MoveRowUp()
    {
        if (!_firstTimeSelected)
        {
            SelectedIndex = _optionsLastIndex;
            _firstTimeSelected = true;
        }
        else
        {
            if (SelectedIndex > 0)
            {
                SelectedIndex -= 1;
            }
        }
    }

    public void ShowOptions()
    {
        Options.Clear();
        Extensions.WriteMessageWithColor("--------- Welcome to Parcel Distribution Center! ---------\n", ConsoleColor.DarkGreen);
        Extensions.WriteMessageWithColor("Select one of the following options (move with the arrows - press enter to select):", ConsoleColor.White);
        Console.WriteLine();
        _cursorLeft = _initialCursorLeft = Console.CursorLeft;
        _cursorTop = _initialCursorTop = Console.CursorTop;
        int counter = 0;
        Options.AddRange(new List<Option>()
        {
            new Option(OptionsEnum.FindPackageByNumber, $"{++counter}. Find package by number."),
            new Option(OptionsEnum.FindPackagesByCourierID, $"{++counter}. Find package by courier ID."),
            new Option(OptionsEnum.FindPackagesByDeliveryMachineID, $"{++counter}. Find packages by delivery machine ID."),
            new Option(OptionsEnum.AddPackage , $"{++counter}. Add new package."),
            new Option(OptionsEnum.EditPackageData, $"{++counter}. Edit package data."),
            new Option(OptionsEnum.DisplayAllPackages, $"{++counter}. Display all packages."),
        });
        _optionsLastIndex = Options.Count - 1;
        foreach (Option option in Options)
        {
            Console.WriteLine($"{option.Statement}");
        }
        Console.WriteLine("\nESC: Close application.");
    }
}