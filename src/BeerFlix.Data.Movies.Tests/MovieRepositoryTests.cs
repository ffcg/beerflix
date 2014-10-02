using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Movies.Tests
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        IMovieService _mockMovieServiceRepository;
        MovieRepository _movieRepository;

        [SetUp]
        public void Setup()
        {
            _mockMovieServiceRepository = new MockMovieService();
            _movieRepository = new MovieRepository(_mockMovieServiceRepository);
        }
       
        [Test]
        public void MovieRepository_SearchMovieTitles_with_empty_searchstring_should_return_empty_list()
        {
            //ACT
            //ARRANGE
            var searchMovieTitles = _movieRepository.SearchMovieTitles();

            //ASSERT
            searchMovieTitles.Count().Should().Be(0);
        }

        [Test]
        public void MovieRepository_SearchMovieTitles_with_searchstring_should_return_list_of_movies()
        {
            //ACT
            //ARRANGE
            var searchMovieTitles = _movieRepository.SearchMovieTitles("searchstring");
            
            //ASSERT
            searchMovieTitles.Should().NotBeNull();
        }

        [Test]
        public void MovieRepository_SearchMovieTitles_with_searchstring_should_return_list_of_3_different_movies()
        {
            //ACT
            //ARRANGE
            var searchMovieTitles = _movieRepository.SearchMovieTitles("3movies");
            
            //ASSERT
            searchMovieTitles.Count().Should().Be(3, "Movie count should be 3");
            var movie0 = searchMovieTitles.ElementAt(0);
            var movie1 = searchMovieTitles.ElementAt(1);
            var movie2 = searchMovieTitles.ElementAt(2);
            movie0.original_title.Should().NotBe(movie1.original_title);
            movie2.original_title.Should().NotBe(movie1.original_title);
            movie1.original_title.Should().NotBe(movie2.original_title);
        }        
    }
    
    public class MockMovieService : IMovieService
    {
        public IEnumerable<Movie> GetMovies(string searchString)
        {
            var movies = new List<Movie>();
            if (searchString.Equals("3movies"))
            {
                movies.AddRange(new List<Movie>
                {
                    new Movie(){original_title = "movie1"}, 
                    new Movie(){original_title = "movie2"}, 
                    new Movie(){original_title = "movie3"}
                });
            }
            return movies;

        }
    }
}
