namespace BeerFlix.Data.Movies
{
    public class UrlBuilder
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public UrlBuilder(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
        }

        public string GetUrlForSearchMovie(string movie)
        {
            movie = System.Web.HttpUtility.UrlEncode(movie);
            var url = string.Format("{0}/search/movie?query={1}&api_key={2}",_baseUrl,movie,_apiKey);
            return url;
        }

        public string GetUrlForGettingMovieById(int id)
        {
            var url = string.Format("{0}/movie/{1}?api_key={2}",_baseUrl, id, _apiKey);
            return url;
        }
    }
}