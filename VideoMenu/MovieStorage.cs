using System;
using System.Collections.Generic;

namespace VideoMenu
{
    public class MovieStorage
    {
        private static List<Movie> movieList = new List<Movie>();
        private static int Id = 1;

        internal int GetId()
        {
            return Id;
        }

        internal void SetId()
        {
            Id++;
        }
        
        internal static void SetList()
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

        private void AddToList(Movie movie)
        {
            movieList.Add(movie);
        }

        internal List<Movie> GetMovieList()
        {
            return movieList;
        }
    }
}