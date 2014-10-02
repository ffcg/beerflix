using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Movies.Tests
{
    [TestFixture]
    public class UrlBuilderTests
    {
        UrlBuilder _urlBuilder;

        [SetUp]
        public void Setup()
        {
            _urlBuilder = new UrlBuilder("http://baseadress", "apikey");
        }

        [Test]
        public void UrlBuilder_GetUrlForSearchMovie_with_param_MovieTitle_should_return_correct_url()
        {
            //ARRANGE

            var expected = "http://baseadress/search/movie?query=MovieTitle&api_key=apikey";
                 
            //ACT
            var urlForSearchMovie = _urlBuilder.GetUrlForSearchMovie("MovieTitle");
            
            //ASSERT
            urlForSearchMovie.Should().Be(expected);
        }

        [Test]
        public void UrlBuilder_GetUrlForSearchMovie_with_param_containing_spaces_should_return_correct_url()
        {
            //ARRANGE
            var expected = "http://baseadress/search/movie?query=Dark+Knight&api_key=apikey";

            //ACT
            var urlForSearchMovie = _urlBuilder.GetUrlForSearchMovie("Dark Knight");
            
            //ASSERT
            urlForSearchMovie.Should().Be(expected);
        }

        [Test]
        public void UrlBuilder_GetUrlForGettingMovieById_with_id_5_should_return_correct_url()
        {
            //ARRANGE
            var expected = "http://baseadress/movie/5?api_key=apikey";

            //ACT
            var urlForGettingMovieById = _urlBuilder.GetUrlForGettingMovieById(5);

            //ASSERT
            urlForGettingMovieById.Should().Be(expected);
        }
    }
}
