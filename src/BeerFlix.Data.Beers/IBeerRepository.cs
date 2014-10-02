using System.Collections.Generic;

namespace BeerFlix.Data.Beers
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetBeersByCriteria(SearchCriteria criteria);
    }
}