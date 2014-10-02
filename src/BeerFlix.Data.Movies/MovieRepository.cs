using System;
using System.Collections.Generic;

namespace BeerFlix.Data.Movies
{
    public class MovieRepository
    {
        public IEnumerable<Movie> SearchMovieTitles(string searchString = null)
        {
            return new List<Movie>();
        }
    }
}
