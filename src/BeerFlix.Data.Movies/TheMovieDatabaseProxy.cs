using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace BeerFlix.Data.Movies
{
    public class TheMovieDatabase : IMovieService
    {

        private const string apiKey = "636275701660cf4f5449224c27027c1d";
        private readonly HttpClient _httpClient;
        public TheMovieDatabase(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://api.themoviedb.org/3");
        }

        public IEnumerable<Movie> GetMovies(string searchString)
        {
            var adress = AppendApiKey(string.Format("{0}/search/movie?query={1}",_httpClient.BaseAddress, WebUtility.HtmlEncode(searchString)));
            var httpResponseMessage = _httpClient.GetAsync(adress).Result;
            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchMovieResponse>(result).results;        
        }

        private string AppendApiKey(string url)
        {
            return string.Format("{0}&api_key={1}", url, apiKey);
        }
    }
}


        