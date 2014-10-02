using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BeerFlix.Data.Movies
{
    public class TheMovieDatabase : IMovieService
    {
        private readonly HttpClient _httpClient;
        public TheMovieDatabase(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/movie/550?api_key=636275701660cf4f5449224c27027c1d");
        }

        public IEnumerable<Movie> GetMovies(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}