namespace ParcelDistributionCenter.ConsoleUI
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
#pragma warning disable CS8603 // Possible null reference return.
            return data;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static void ReportError(string message)
        {
            WriteMessage(message, ConsoleColor.Red);
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