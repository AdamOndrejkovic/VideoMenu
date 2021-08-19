using System;

namespace VideoMenu
{
    internal class Menu
    {
        internal static int ShowMenu(string[] menuItems)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Pick a option");
            Console.ResetColor();
            int id = 1;
            foreach (var menuItem in menuItems)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{id}. {menuItem}");
                id++;
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection is < 1 or > 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to choose number between 1-6");
                Console.ResetColor();
            }
            Console.ResetColor();
            return selection;
        }
    }
}