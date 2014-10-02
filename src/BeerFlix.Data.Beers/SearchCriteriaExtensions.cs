using System.Linq;

namespace BeerFlix.Data.Beers
{
    public static class SearchCriteriaExtensions
    {
        public static bool MatchesCriteria(this Beer beer, SearchCriteria criteria)
        {
            if ((criteria.CountryIsoCode != null) && !criteria.CountryIsoCode.Equals(beer.Country)) return false;
            if ((criteria.Style != null) && !beer.Styles.Any(s => s.Name.Equals(criteria.Style.Name))) return false;
            if ((criteria.Producer != null) && (beer.Producer.Name != criteria.Producer.Name)) return false;
            if (criteria.AlcoholByVolumeMin >= beer.AlcoholByVolume ||
                criteria.AlcoholByVolumeMax <= beer.AlcoholByVolume) return false;
            if (criteria.AlcoholPerPriceUnitMin >= beer.AlcoholPerPriceUnit ||
                criteria.AlcoholPerPriceUnitMax <= beer.AlcoholPerPriceUnit) return false;
            return true;
        }
    }
}