using ParcelDistributionCenter.Model.Enums;//pawel

namespace ParcelDistributionCenter.ConsoleUI;

public class OptionsHandler
{
    private int cursorLeft;
    private int cursorTop;
    private bool firstTimeSelected = false;
    private int initialCursorLeft;
    private int initialCursorTop;
    private int optionsLastIndex;
    public List<Option> Options { get; private set; } = new();
    public int SelectedIndex { get; private set; }

    public void DrawSelectedRow(int selectedIndex)
    {
        cursorTop = initialCursorTop;
        cursorLeft = initialCursorLeft;
        if (selectedIndex != -1)
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop + i);
                var backgroundColor = selectedIndex == i ? Console.BackgroundColor = ConsoleColor.DarkCyan : ConsoleColor.Black;
                Console.BackgroundColor = backgroundColor;
                Console.WriteLine(Options[i].Statement);
            }
        }
    }

    public void MoveRowDown()
    {
        if (!firstTimeSelected)
        {
            SelectedIndex = 0;
            firstTimeSelected = true;
        }
        else
        {
            if (SelectedIndex < optionsLastIndex)
            {
                SelectedIndex += 1;
            }
        }
    }

    public void MoveRowUp()
    {
        if (!firstTimeSelected)
        {
            SelectedIndex = optionsLastIndex;
            firstTimeSelected = true;
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
        Extensions.WriteMessageWithColor("--------- Welcome to Package3000! ---------\n", ConsoleColor.DarkGreen);
        Extensions.WriteMessageWithColor("Select one of the following options (move with the arrows - press enter to select):", ConsoleColor.White);
        Console.WriteLine();
        cursorLeft = initialCursorLeft = Console.CursorLeft;
        cursorTop = initialCursorTop = Console.CursorTop;
        int counter = 0;
        Options.AddRange(new List<Option>()
        {
            new Option(OptionsEnum.FindPackageByNumber, $"{++counter}. Find package by number."),
            new Option(OptionsEnum.FindPackageByCourierID, $"{++counter}. Find package by courier ID."),
            new Option(OptionsEnum.AddPackage , $"{++counter}. Add new package."),
            new Option(OptionsEnum.EditPackageData, $"{++counter}. Edit package data."),
            new Option(OptionsEnum.DisplayAllPackages, $"{++counter}. Display all packages data."),
            new Option(OptionsEnum.DisplayAllPackagesInPackageMachine, $"{++counter}. Display all packages data in package machine ."),

        });
        optionsLastIndex = Options.Count - 1;
        foreach (Option option in Options)
        {
            Console.WriteLine($"{option.Statement}");
        }
        Console.WriteLine("\nESC: Close application.");
    }
}