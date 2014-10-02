namespace BeerFlix.Data.Beers
{
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            AlcoholPerPriceUnitMin = double.MinValue;
            AlcoholPerPriceUnitMax = double.MaxValue;
            AlcoholByVolumeMin = double.MinValue;
            AlcoholByVolumeMax = double.MaxValue;
            PriceMin = double.MinValue;
            PriceMax = double.MaxValue;
        }

        public string Country { get; set; }
        public string Style { get; set; }
        public double AlcoholPerPriceUnitMin { get; set; }
        public double AlcoholPerPriceUnitMax { get; set; }
        public double AlcoholByVolumeMin { get; set; }
        public double AlcoholByVolumeMax { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
    }
}