using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerFlix.Data
{
    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public IEnumerable<BeerStyle> Styles { get; set; }
        public BeerProducer Producer { get; set; }
        public double Price { get; set; }
        public double AlcoholPerPriceUnit { get; set; }
        public double AlcoholByVolume { get; set; }
    }

    public class BeerStyle
    {
        public string Name { get; set; }
    }

    public class BeerProducer
    {
        public string Name { get; set; }
    }
}
