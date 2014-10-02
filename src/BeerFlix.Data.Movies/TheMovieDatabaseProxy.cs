using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeerFlix.Data.Movies
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies(string searchString);
        Movie GetMovieById(int id);
    }
    public class TheMovieDatabaseService : IMovieService
    {
        private const string ApiKey = "636275701660cf4f5449224c27027c1d";
        private readonly HttpClient _httpClient;
        private readonly UrlBuilder _urlBuilder;

        public TheMovieDatabaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.themoviedb.org/3");
            _urlBuilder = new UrlBuilder(_httpClient.BaseAddress.ToString(), ApiKey);
        }

        public IEnumerable<Movie> GetMovies(string searchString)
        {
            var adress = _urlBuilder.GetUrlForSearchMovie(searchString);
            var httpResponseMessage = _httpClient.GetAsync(adress).Result;
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchMovieResponse>(result).results;        
        }

        public Movie GetMovieById(int id)
        {
            var adress = _urlBuilder.GetUrlForGettingMovieById(id);
            var httpResponseMessage = _httpClient.GetAsync(adress).Result;
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Movie>(result);
        }
    }
}


        