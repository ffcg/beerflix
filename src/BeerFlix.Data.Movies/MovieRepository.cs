using System.Collections.Generic;

namespace BeerFlix.Data.Movies
{
    public class MovieRepository
    {
        private readonly IMovieService _movieService;
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
