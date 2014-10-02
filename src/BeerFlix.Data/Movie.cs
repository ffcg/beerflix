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
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string budget { get; set; }
        public List<Genre> genres { get; set; }
        public string original_title { get; set; }
        public double popularity { get; set; }
        public string release_date { get; set; }
        public long revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguage> spoken_languages { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public List<ProductionCountry> production_countries { get; set; }
    }

    public class ProductionCountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class SpokenLanguage
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }    
    }

    public class Genre  
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}