namespace BeerFlix.Data.Beers
{
    public static class SearchCriteriaExtensions
    {
        public static bool MatchesCriteria(this Beer beer, SearchCriteria criteria)
        {
            if ((criteria.Country != null) && !criteria.Country.Equals(beer.Country)) return false;
            if ((criteria.Style != null) && !criteria.Style.Equals(beer.Style)) return false;
            if (criteria.AlcoholByVolumeMin >= beer.AlcoholByVolume ||
                criteria.AlcoholByVolumeMax <= beer.AlcoholByVolume) return false;
            if (criteria.AlcoholPerPriceUnitMin >= beer.AlcoholPerPriceUnit ||
                criteria.AlcoholPerPriceUnitMax <= beer.AlcoholPerPriceUnit) return false;
            return true;
        }
    }
}