using System.Collections.Generic;

namespace BeerFlix.Data.Beers
{
    public interface IBeerRepository
    {
        IEnumerable<BeerStyle> GetBeerStyles();
        IEnumerable<BeerProducer> GetBeerProducers();
        IEnumerable<Beer> GetBeersByCriteria(SearchCriteria criteria);
    }
}