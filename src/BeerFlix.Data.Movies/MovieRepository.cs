using System.Collections.Generic;
using System.Diagnostics;

namespace BeerFlix.Data.Movies
{
    public class MovieRepository
    {
        private IMovieService _movieService;
        public MovieRepository(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IEnumerable<Movie> SearchMovieTitles(string searchString = null)
        {
            return _movieService.GetMovies(searchString ?? string.Empty);
        }
    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(string searchString);
     
    }
}
