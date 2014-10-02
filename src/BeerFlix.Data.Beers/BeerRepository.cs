using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BeerFlix.Data.Beers
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ExcelReader<SystembolagetArticleRow> _reader;
        private readonly ICountryRepository _countryRepository;
        private readonly IEnumerable<Beer> _beers;
        private readonly IEnumerable<BeerStyle> _beerStyles;
        private readonly IEnumerable<BeerProducer> _beerProducers;
       

        public BeerRepository(ExcelReader<SystembolagetArticleRow> reader, ICountryRepository countryRepository)
        {
            _reader = reader;
            _countryRepository = countryRepository;
            var fileStream = File.Open(@"Data/systembolaget.xlsx",
                FileMode.Open, FileAccess.Read, FileShare.Read);

            var systembolagetArticleRows = _reader.GetAllRows(fileStream, @"AllaArtiklar");
            _beerStyles = systembolagetArticleRows
                .SelectMany(a => GetBeerStylesFromList(a.Varugrupp))
                .Distinct()
                .Select(s => new BeerStyle(){Name = s})
                .ToArray();
            var beerStyleLookup = _beerStyles.ToDictionary(bs => bs.Name);

            _beerProducers = systembolagetArticleRows
                .Select(a => a.Producent)
                .Distinct()
                .Where(p => p != null)
                .Select(p => new BeerProducer(){Name = p.Trim()})
                .ToArray();
            var beerProducersLookup = _beerProducers.ToDictionary(bp => bp.Name);

            var swedishCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("sv-SE");
            var countries = systembolagetArticleRows
                .Select(a => a.Ursprunglandnamn)
                .Distinct()
                .Select(a => new { Country = a, ISOCode = _countryRepository.GetCountryCodeForLocalizedCountryName(a, swedishCultureInfo)})
                .ToDictionary(a => a.Country, a => a.ISOCode);

            _beers = _reader.GetAllRows(fileStream, @"AllaArtiklar")
                .Select(
                    a =>
                        new Beer()
                        {
                            AlcoholByVolume = a.Alkoholhalt,
                            AlcoholPerPriceUnit = a.Alkoholhalt/a.PrisPerLiter,
                            Country = countries.ContainsKey(a.Ursprunglandnamn) ? countries[a.Ursprunglandnamn] : a.Ursprunglandnamn,
                            Name = a.Namn,
                            Price = a.Prisinklmoms,
                            Styles = new List<BeerStyle>(GetBeerStylesFromList(a.Varugrupp).Select(vg => beerStyleLookup[vg])),
                            Producer = a.Producent != null ? beerProducersLookup[a.Producent] : null,
                        })
                .ToArray();
        }

        private IEnumerable<string> GetBeerStylesFromList(string stylesList)
        {
            return stylesList
                .Replace("och", ",")
                .Split(',')
                .Select(s => s.Trim())
                .Where(s => !s.Equals("öl", StringComparison.InvariantCultureIgnoreCase))
                .ToArray();
        }

        public IEnumerable<BeerStyle> GetBeerStyles()
        {
            return _beerStyles;
        }

        public IEnumerable<BeerProducer> GetBeerProducers()
        {
            return _beerProducers;
        }

        public IEnumerable<Beer> GetBeersByCriteria(SearchCriteria criteria)
        {
            return _beers.Where(b => b.MatchesCriteria(criteria)).Take(3).ToArray();
        }
    }

    public interface ICountryRepository
    {
        string GetCountryCodeForLocalizedCountryName(string localizedCountryName,
            System.Globalization.CultureInfo cultureInfo);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly string[][] _countryData = new[]
        {
            new[] {"Afghanistan", "AF"},
            new[] {"Albanien", "AL"},
            new[] {"Algeriet", "DZ"},
            new[] {"Andorra", "AD"},
            new[] {"Angola", "AO"},
            new[] {"Antigua och Barbuda", "AG"},
            new[] {"Arabemiraten, Förenade", "AE"},
            new[] {"Argentina", "AR"},
            new[] {"Armenien", "AM"},
            new[] {"Australien", "AU"},
            new[] {"Azerbajdzjan", "AZ"},
            new[] {"Bahamas", "BS"},
            new[] {"Bahrain", "BH"},
            new[] {"Bangladesh", "BD"},
            new[] {"Barbados", "BB"},
            new[] {"Belgien", "BE"},
            new[] {"Belize", "BZ"},
            new[] {"Benin", "BJ"},
            new[] {"Bermuda", "BM"},
            new[] {"Bhutan", "BT"},
            new[] {"Bolivia", "BO"},
            new[] {"Bosnien och Hercegovina", "BA"},
            new[] {"Botswana", "BW"},
            new[] {"Brasilien", "BR"},
            new[] {"Brunei Darussalam", "BN"},
            new[] {"Bulgarien", "BG"},
            new[] {"Burkina Faso", "BF"},
            new[] {"Burundi", "BI"},
            new[] {"Centralafrikanska Republiken", "CF"},
            new[] {"Chile", "CL"},
            new[] {"Colombia", "CO"},
            new[] {"Comorerna", "KM"},
            new[] {"Costa Rica", "CR"},
            new[] {"Cypern", "CY"},
            new[] {"Danmark", "DK"},
            new[] {"Demokratiska Republiken", "CD"},
            new[] {"Djibouti", "DJ"},
            new[] {"Dominica", "DM"},
            new[] {"Dominikanska Republiken", "DO"},
            new[] {"Ecuador", "EC"},
            new[] {"Egypten", "EG"},
            new[] {"Ekvatorialguinea", "GQ"},
            new[] {"El Salvador", "SV"},
            new[] {"Elfenbenskusten", "CI"},
            new[] {"Eritrea", "ER"},
            new[] {"Estland", "EE"},
            new[] {"Etiopien", "ET"},
            new[] {"Fijiöarna", "FJ"},
            new[] {"Filippinerna", "PH"},
            new[] {"Finland", "FI"},
            new[] {"Frankrike", "FR"},
            new[] {"Gabon", "GA"},
            new[] {"Gambia", "GM"},
            new[] {"Georgien", "GE"},
            new[] {"Ghana", "GH"},
            new[] {"Gibraltar", "GI"},
            new[] {"Grekland", "GR"},
            new[] {"Grenada", "GD"},
            new[] {"Guatemala", "GT"},
            new[] {"Guinea", "GN"},
            new[] {"Guinea-Bissau", "GW"},
            new[] {"Guyana", "GY"},
            new[] {"Haiti", "HT"},
            new[] {"Honduras", "HN"},
            new[] {"Indien", "IN"},
            new[] {"Indonesien", "ID"},
            new[] {"Irak", "IQ"},
            new[] {"Iran", "IR"},
            new[] {"Irland", "IE"},
            new[] {"Island", "IS"},
            new[] {"Israel", "IL"},
            new[] {"Italien", "IT"},
            new[] {"Jamaica", "JM"},
            new[] {"Japan", "JP"},
            new[] {"Jemen", "YE"},
            new[] {"Jordanien", "JO"},
            new[] {"Kambodja", "KH"},
            new[] {"Kamerun", "CM"},
            new[] {"Kanada", "CA"},
            new[] {"Kap Verde", "CV"},
            new[] {"Kazakstan", "KZ"},
            new[] {"Kenya", "KE"},
            new[] {"Kina", "CN"},
            new[] {"Kirgistan", "KG"},
            new[] {"Kiribati", "KI"},
            new[] {"Kongo", "CG"},
            new[] {"Korea, Nord-", "KP"},
            new[] {"Korea, Syd-", "KR"},
            new[] {"Kroatien", "HR"},
            new[] {"Kuba", "CU"},
            new[] {"Kuwait", "KW"},
            new[] {"Laos", "LA"},
            new[] {"Lesotho", "LS"},
            new[] {"Lettland", "LV"},
            new[] {"Libanon", "LB"},
            new[] {"Liberia", "LR"},
            new[] {"Libyen", "LY"},
            new[] {"Liechtenstein", "LI"},
            new[] {"Litauen", "LT"},
            new[] {"Luxemburg", "LU"},
            new[] {"Madagaskar", "MG"},
            new[] {"Makedonien", "MK"},
            new[] {"Malawi", "MW"},
            new[] {"Malaysia", "MY"},
            new[] {"Maldiverna", "MV"},
            new[] {"Mali", "ML"},
            new[] {"Malta", "MT"},
            new[] {"Marocko", "MA"},
            new[] {"Marshallöarna", "MH"},
            new[] {"Mauretanien", "MR"},
            new[] {"Mauritius", "MU"},
            new[] {"Mexiko", "MX"},
            new[] {"Mikronesien", "FM"},
            new[] {"Mocambique", "MZ"},
            new[] {"Moldavien", "MD"},
            new[] {"Monaco", "MC"},
            new[] {"Mongoliet", "MN"},
            new[] {"Myanmar", "MM"},
            new[] {"Namibia", "NA"},
            new[] {"Nauru", "NR"},
            new[] {"Nederländerna", "NL"},
            new[] {"Nepal", "NP"},
            new[] {"Nicaragua", "NI"},
            new[] {"Niger", "NE"},
            new[] {"Nigeria", "NG"},
            new[] {"Norge", "NO"},
            new[] {"Nya Guinea", "PG"},
            new[] {"Nya Zeeland", "NZ"},
            new[] {"och Montenegro", "CS"},
            new[] {"Oman", "OM"},
            new[] {"Pakistan", "PK"},
            new[] {"Palau", "PW"},
            new[] {"Panama", "PA"},
            new[] {"Paraguay", "PY"},
            new[] {"Peru", "PE"},
            new[] {"Polen", "PL"},
            new[] {"Portugal", "PT"},
            new[] {"Qatar", "QA"},
            new[] {"Rumänien", "RO"},
            new[] {"Rwanda", "RW"},
            new[] {"Ryssland", "RU"},
            new[] {"Saint Lucia", "LC"},
            new[] {"Salomonöarna", "SB"},
            new[] {"Samoa", "WS"},
            new[] {"San Marino", "SM"},
            new[] {"Saudiarabien", "SA"},
            new[] {"Schweiz", "CH"},
            new[] {"Senegal", "SN"},
            new[] {"Seychellerna", "SC"},
            new[] {"Sierra Leone", "SL"},
            new[] {"Singapore", "SG"},
            new[] {"Slovakien", "SK"},
            new[] {"Slovenien", "SI"},
            new[] {"Somalia", "SO"},
            new[] {"Spanien", "ES"},
            new[] {"Sri Lanka", "LK"},
            new[] {"Storbritannien och Nordirland", "GB"},
            new[] {"Sudan", "SD"},
            new[] {"Surinam", "SR"},
            new[] {"Swaziland", "SZ"},
            new[] {"Sverige", "SE"},
            new[] {"Sydafrika", "ZA"},
            new[] {"Syrien", "SY"},
            new[] {"Tadjikistan", "TJ"},
            new[] {"Taiwan", "TW"},
            new[] {"Tanzania", "TZ"},
            new[] {"Tchad", "TD"},
            new[] {"Thailand", "TH"},
            new[] {"Tjeckien", "CZ"},
            new[] {"Togo", "TG"},
            new[] {"Tonga", "TO"},
            new[] {"Trinidad och Tobago", "TT"},
            new[] {"Tunisien", "TN"},
            new[] {"Turkiet", "TR"},
            new[] {"Turkmenistan", "TM"},
            new[] {"Tuvalu", "TV"},
            new[] {"Tyskland", "DE"},
            new[] {"Uganda", "UG"},
            new[] {"Ukraina", "UA"},
            new[] {"Ungern", "HU"},
            new[] {"Uruguay", "UY"},
            new[] {"USA", "US"},
            new[] {"Uzbekistan", "UZ"},
            new[] {"Vanuatu", "VU"},
            new[] {"Vatikanstaten", "VA"},
            new[] {"Venezuela", "VE"},
            new[] {"Vietnam", "VN"},
            new[] {"Vitryssland", "BY"},
            new[] {"Zambia", "ZM"},
            new[] {"Zimbabwe", "ZW"},
            new[] {"Österrike", "AT"},
            new[] {"Östtimor", "TL"},
            new[] {"Saint och Grenadinerna", "VC"},
            new[] {"Saint och Nevis", "KN"},
            new[] {"Sao och Principe", "ST"},
        };
        public string GetCountryCodeForLocalizedCountryName(string localizedCountryName,
            System.Globalization.CultureInfo cultureInfo)
        {
            if( !cultureInfo.TwoLetterISOLanguageName.Equals("sv", StringComparison.InvariantCultureIgnoreCase))
                throw new NotSupportedException("This implementation only supports Swedish country names");

            var country = _countryData.FirstOrDefault(
                c => c[0].Equals(localizedCountryName, StringComparison.InvariantCultureIgnoreCase));
            if (country != null) return country[1];
            return null;
        }
    }
}
