using System;
using System.Collections.Generic;
using System.Threading;

namespace VideoMenu
{
    class Program
    {
        private static readonly StringConstants StringConstants = new StringConstants();
        private static readonly MovieStorage MovieStorage = new MovieStorage();
        private static MovieManager movieManager = new MovieManager();
        static void Main(string[] args)
        {
            ConsoleSpinner.ShowSimplePercentage();
            Console.Clear();
            
            MovieStorage.SetList();
            Console.WriteLine();

            var selection = Menu.ShowMenu(StringConstants.menuItems);
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        movieManager.ShowMovies();
                        break;
                    case 2:
                        movieManager.AddMovie();
                        break;
                    case 3:
                        movieManager.EditMovie();
                        break;
                    case 4:
                        movieManager.DeleteMovie();
                        break;
                    case 5:
                        movieManager.Filter();
                        break;
                    default:
                        break;
                }
                
                selection = Menu.ShowMenu(StringConstants.menuItems);
            }

            Console.WriteLine(StringConstants.exit);
        }
    }
}