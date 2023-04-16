namespace ParcelDistributionCenter.ConsoleUI.Options
{
    public static class Extensions
    {
        public static string GetData(string inputString)
        {
            Console.ResetColor();
            Console.Write($"{inputString}: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string data = Console.ReadLine();
            Console.ResetColor();
            return data;
        }

        public static void ReportError(string message)
        {
            WriteMessage(message, ConsoleColor.Red);
        }

        public static void WriteEndMessage()
        {
            WriteMessageWithColor("Press any key to go back to main window.");
            Console.ReadKey();
        }

        public static void WriteMessageWithColor(string message, ConsoleColor color = ConsoleColor.DarkCyan)
        {
            WriteMessage(message, color);
        }

        private static void WriteMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}