using System;
using System.Collections.Generic;

namespace BeerFlix.Data.Beers
{
    public class BeerRepository
    {
        


        public IEnumerable<Beer> GetBeersByCharacteristics(
            double? alcoholPerPriceUnit = null,
            string country = null,
            string style = null,
            string alcoholByVolume = null,
            decimal? price = null)
        {
            yield return new Beer() { Name = "beer 1" };
            yield return new Beer() { Name = "beer 2" };
            yield return new Beer() { Name = "beer 3" };
        }
    }
}
