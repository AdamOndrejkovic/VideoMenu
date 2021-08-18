using System;
using System.Drawing;
using System.Threading;

namespace VideoMenu
{
    public class ConsoleSpinner
    {
        public static void ShowSimplePercentage()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rStarting: {i}%   ");
                Thread.Sleep(25);
            }
        }
    }
}