using System;
using System.Collections.Generic;

namespace VideoMenu
{
    class Program
    {
        private static int Id = 1;
        private static List<Movie> movieList = new List<Movie>();
        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "Show all movies",
                "Add movie",
                "Edit movie",
                "Delete movie",
                "Search movie",
                "Exit"
            };

            SetList();

            var selection = ShowMenu(menuItems);
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ShowMovies();
                        break;
                    case 2:
                        AddMovie();
                        break;
                    case 3:
                        Console.WriteLine("Show All Movies");
                        break;
                    case 4:
                        Console.WriteLine("Show All Movies");
                        break;
                    case 5:
                        Console.WriteLine("Show All Movies");
                        break;
                    default:
                        break;
                }
                
                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Exited");
        }

        private static void AddMovie()
        {
            Console.WriteLine("Movie Title");
            var title = Console.ReadLine();
            
            Console.WriteLine("Release Date");
            var releaseDate = Console.ReadLine();
            
            Console.WriteLine("Story Line");
            var storyLine = Console.ReadLine();
            
            Console.WriteLine("Movie Genre");
            var genre = Console.ReadLine();
            
            Console.WriteLine("Movie was added");

            movieList.Add(new Movie()
            {
                Id = Id++,
                Title = title,
                ReleaseDate = new DateTime(Convert.ToInt32(releaseDate), 1, 1),
                StoryLine = storyLine,
                Genre = genre
            });

        }

        private static void ShowMovies()
        {
            foreach (var movie in movieList)
            {
                Console.WriteLine($"Id: {movie.Id} Title: {movie.Title} Release Date: {movie.ReleaseDate.Year}");
            }
        }

        private static void SetList()
        {
            movieList.Add(new Movie()
            {
                Id = Id++,
                Title = "Pirates of the Caribbean",
                ReleaseDate = new DateTime(Convert.ToInt32("2013"), 1, 1),
                StoryLine = "Some storyline",
                Genre = "Action"
                
            });

            movieList.Add(new Movie()
            {
                Id = Id++,
                Title = "Star Wars",
                ReleaseDate = new DateTime(Convert.ToInt32("1977"), 1, 1),
                StoryLine = "May the force be with you",
                Genre = "Adventure"
            });
        }

        private static int ShowMenu(string[] menuItems)
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
            || selection is < 1or > 5)
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