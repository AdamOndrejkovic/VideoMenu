using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace VideoMenu
{
    public class MovieManager
    {
        private static readonly MovieStorage MovieStorage = new MovieStorage();

        public void DeleteMovie()
        {
            Movie movieToRemove = FindMovieById();
            if (movieToRemove != null)
            {
                MovieStorage.GetMovieList().Remove(movieToRemove);
            }
        }

        public void EditMovie()
        {
            Movie movieToEdit = FindMovieById();

            Console.WriteLine($"Current Title: {movieToEdit.Title}");
            var newTitle = Console.ReadLine();
            
            Console.WriteLine($"Current Release Date: {movieToEdit.ReleaseDate.Year}");
            var newReleaseDate = Console.ReadLine();
            
            Console.WriteLine($"Current Story Line: {movieToEdit.StoryLine}");
            var newStoryLine = Console.ReadLine();
            
            Console.WriteLine($"Current Genre: {movieToEdit.Genre}");
            var newGenre = Console.ReadLine();

            movieToEdit.Title = newTitle;
            movieToEdit.ReleaseDate = new DateTime(Convert.ToInt32(newReleaseDate), 1, 1);
            movieToEdit.StoryLine = newStoryLine;
            movieToEdit.Genre = newGenre;
        }

        private static Movie FindMovieById()
        {
            Console.WriteLine("Write the movie's ID:");
            var input = Console.ReadLine();

            int id;
            if (!int.TryParse(input, out id))
            {
                Console.WriteLine("Please insert a number");
            }

            Movie movieFound = null;
            foreach (Movie movie in MovieStorage.GetMovieList())
            {
                if (movie.Id== id)
                {
                    movieFound = movie;
                }
            }

            return movieFound;
        }
        
        public static Movie FindMovieByTitle()
        {
            Console.WriteLine("Write the movie's title");
            var input = Console.ReadLine();

            
            if (input is { Length: > 0 })
            {
                Console.WriteLine("Please write a title");
            }

            Movie movieFound = null;
            foreach (Movie movie in MovieStorage.GetMovieList())
            {
                if (movie.Title.Contains(input))
                {
                    movieFound = movie;
                }
            }

            return movieFound;
        }

        public void AddMovie()
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

            MovieStorage.GetMovieList().Add(new Movie()
            {
                Id = MovieStorage.GetId(),
                Title = title,
                ReleaseDate = new DateTime(Convert.ToInt32(releaseDate), 1, 1),
                StoryLine = storyLine,
                Genre = genre
            });
            MovieStorage.SetId();
        }

        public void ShowMovies()
        {
            var table = new ConsoleTable("ID", "Title", "Release Date", "Story Line", "Genre");
            foreach (var movie in MovieStorage.GetMovieList())
            {
                table.AddRow(movie.Id, movie.Title, movie.ReleaseDate.Year, movie.StoryLine, movie.Genre);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            table.Write();
            Console.ResetColor();
        }

        public void Filter()
        {
            Console.WriteLine("Select the column you want to filter by (ex. ID)");
            var columnValue = Console.ReadLine();

            Console.WriteLine("Select the value you want to search for");
            var searchValue = Console.ReadLine();

            switch (columnValue.ToLower())
            {
                case "id":
                    FindMovieById(searchValue);
                    break;
                case "title":
                    FindMovieByTitle(searchValue);
                    break;
                case "release date":
                    FindMovieByReleaseDate(searchValue);
                    break;
                case "story line":
                    FindMovieByStoryLine(searchValue);
                    break;
                case "genre":
                    FindMovieByGenre(searchValue);
                    break;
                default:
                    Console.WriteLine("Incorrect value try again");
                    break;
            }
        }

        private void FindMovieByGenre(string? searchValue)
        {
            if (searchValue == null)
            {
                searchValue = "action";
            }

            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in MovieStorage.GetMovieList())
            {
                if (movie.Genre.ToLower().Contains(searchValue))
                {
                    filteredMovies.Add(movie);
                }
            }
            
            ShowMovies(filteredMovies);
        }

        private void FindMovieByStoryLine(string? searchValue)
        {
            if (searchValue == null)
            {
                searchValue = "cool story";
            }

            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in MovieStorage.GetMovieList())
            {
                if (movie.StoryLine.ToLower().Contains(searchValue))
                {
                    filteredMovies.Add(movie);
                }
            }
            
            ShowMovies(filteredMovies);
        }

        private void FindMovieByReleaseDate(string? searchValue)
        {
            if (searchValue == null)
            {
                searchValue = "2021";
            }

            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in MovieStorage.GetMovieList())
            {
                if (movie.ReleaseDate.Year.ToString().Contains(searchValue))
                {
                    filteredMovies.Add(movie);
                }
            }
            
            ShowMovies(filteredMovies);
        }

        private void FindMovieByTitle(string? searchValue)
        {
            if (searchValue == null)
            {
                searchValue = "Star Wars";
            }

            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in MovieStorage.GetMovieList())
            {
                if (movie.Title.ToLower().Contains(searchValue))
                {
                    filteredMovies.Add(movie);
                    Console.WriteLine("found");
                }
            }

            Console.WriteLine("Filtering by title");
            ShowMovies(filteredMovies);
        }

        private void FindMovieById(string? searchValue)
        {
            if (searchValue == null)
            {
                searchValue = "1" ;
            }

            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in MovieStorage.GetMovieList())
            {
                if (movie.Id.ToString().Contains(searchValue))
                {
                    filteredMovies.Add(movie);
                }
            }
            
            ShowMovies(filteredMovies);
        }

        private void ShowMovies(List<Movie> filteredMovies)
        {
            var table = new ConsoleTable("ID", "Title", "Release Date", "Story Line", "Genre");
            foreach (var movie in filteredMovies)
            {
                table.AddRow(movie.Id, movie.Title, movie.ReleaseDate.Year, movie.StoryLine, movie.Genre);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            table.Write();
            Console.ResetColor();
        }
    }
}