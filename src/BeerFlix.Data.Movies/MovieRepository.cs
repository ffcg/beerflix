using System.Collections.Generic;

namespace BeerFlix.Data.Movies
{
    
    public class MovieRepository : IMovieRepository
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

        public Movie GetMovieById(int id)
        {
            return _movieService.GetMovieById(id);
        }
    }

    public interface IMovieRepository
    {
        IEnumerable<Movie> SearchMovieTitles(string searchString);
        Movie GetMovieById(int id);
    }
}
