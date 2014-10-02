using System.Collections;
using System.Collections.Generic;

namespace BeerFlix.Web.Models.Home
{
    public class Index
    {
        public int BeerCount { get; set; }
        public int BeerStylesCount { get; set; }
        public IEnumerable<string> SelectBeerStyleNames { get; set; }
        public int BeerProducersCount { get; set; }
    }
}