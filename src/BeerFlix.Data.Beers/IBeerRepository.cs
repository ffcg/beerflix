using System.Collections.Generic;

namespace BeerFlix.Data.Beers
{
    public interface IBeerRepository
    {
        int GetBeerCount();
        IEnumerable<BeerStyle> GetBeerStyles();
        IEnumerable<BeerProducer> GetBeerProducers();
        IEnumerable<Beer> GetBeersByCriteria(SearchCriteria criteria);
    }
}