using System.Collections.Generic;

namespace BeerFlix.Data
{

    public class SearchMovieResponse
    {
        public string page { get; set; }
        public string total_pages { get; set; }
        public List<Movie> results { get; set; }
        public string total_results { get; set; }
    }
    public class Movie
    {
        public string adult { get; set; }
        public string budget { get; set; }
        //public List<Genre> genres { get; set; }
        public string original_title { get; set; }

    }

    public class Genre  
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}