using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Movies.Tests
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        private IMovieService _mockMovieServiceRepository;
        private MovieRepository _movieRepository;

        [SetUp]
        public void Setup()
        {
            _mockMovieServiceRepository = new MockMovieService();
            _movieRepository = new MovieRepository(_mockMovieServiceRepository);
        }

        [Test]
        public void MovieRepository_SearchMovieTitles_with_empty_searchstring_should_return_empty_list()
        {
            //ARRANGE
            //ACT
            var searchMovieTitles = _movieRepository.SearchMovieTitles();

            //ASSERT
            searchMovieTitles.Count().Should().Be(0);
        }

        [Test]
        public void MovieRepository_SearchMovieTitles_with_searchstring_should_return_list_of_movies()
        {
            //ARRANGE
            //ACT
            var searchMovieTitles = _movieRepository.SearchMovieTitles("searchstring");

            //ASSERT
            searchMovieTitles.Should().NotBeNull();
        }


        [Test]
        public void MovieRepository_SearchMovieTitles_with_searchstring_should_return_list_of_3_different_movies()
        {
            //ARRANGE
            //ACT
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


        [Test]
        public void MovieRepository_GetMovieById_with_id_subzero_should_return_empty_movie()
        {
            //ARRANGE
            //ACT
            var movieById = _movieRepository.GetMovieById(-1);

            //ASSERT
            movieById.title.Should().BeNull("Title should be empty");
        }

        [Test]
        public void MovieRepository_GetMovieById_with_existing_id_should_return_movie()
        {
            //ARRANGE
            var expectedMovie = new Movie()
            {
                title = "MovieTitle4"
            };
            //ACT
            var movieById = _movieRepository.GetMovieById(4);
            
            //ASSERT
            movieById.title.Should().Be(expectedMovie.title, "Title should be MovieTitle4");

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
                    new Movie() {original_title = "movie1"},
                    new Movie() {original_title = "movie2"},
                    new Movie() {original_title = "movie3"}
                });
            }
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            return MockMovies().FirstOrDefault(x => x.id == id) ?? new Movie();
        }

        private IEnumerable<Movie> MockMovies()
        {
            var movies = new List<Movie>();
            for(int i = 1; i<10;i++)
            {
                movies.Add(new Movie() {title = String.Format("MovieTitle{0}", i), id = i});
            }
            return movies;
        }
    }
}