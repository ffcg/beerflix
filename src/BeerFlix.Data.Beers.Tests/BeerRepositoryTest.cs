using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Beers.Tests
{
    public class BeerRepositoryTest
    {
        [Test]
        public void BeerRepository_GetBeersByCharacteristics_with_emtpy_args_should_return_3_random_beers()
        {
            // Act
            var repository = new BeerRepository();

            // Arrange
            var beers = repository.GetBeersByCharacteristics();

            // Assert
            beers.Should().HaveCount(3);
            var beer0 = beers.ElementAt(0);
            var beer1 = beers.ElementAt(1);
            var beer2 = beers.ElementAt(2);

            beer0.Name.Should().NotBe(beer1.Name);
            beer2.Name.Should().NotBe(beer1.Name);
            beer0.Name.Should().NotBe(beer2.Name);
        }


    }
}
