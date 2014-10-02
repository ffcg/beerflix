using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Movies.Tests
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        [Test]
        public void MovieRepository_SearchMovieTitles_with_empty_searchstring_should_return_empty_list()
        {
            //ACT
            var movieRepository = new MovieRepository();

            //ARRANGE
            var searchMovieTitles = movieRepository.SearchMovieTitles();

            //ASSERT
            searchMovieTitles.Count().Should().Be(0);
        }
    }
}
