using System;

namespace MinimumBackboneConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome. Here you can use the Kraskal's algorithm.");
            ConsoleUI ui = new ConsoleUI();
            ui.GraphFromFile();

            Console.WriteLine("Do you want to enter your  own graph?  Press 1 if you want. Otherwise press 0.");
            if (Int32.Parse(Console.ReadLine()) == 1) ui.GraphFromConsole();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
