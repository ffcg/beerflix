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
        public string Style { get; set; }
        public decimal Price { get; set; }
        public double AlcoholPerPriceUnit { get; set; }
        public double AlcoholByVolume { get; set; }
    }
}
