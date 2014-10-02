using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeerFlix.Data.Beers
{
    public class BeerRepository
    {
        private readonly ExcelReader<SystembolagetArticleRow> _reader;
        private readonly IEnumerable<Beer> _beers;

        public BeerRepository(ExcelReader<SystembolagetArticleRow> reader)
        {
            _reader = reader;
            var fileStream = File.Open(@"Data/systembolaget.xlsx",
                FileMode.Open, FileAccess.Read, FileShare.Read);

            _beers = _reader.GetAllRows(fileStream, @"AllaArtiklar")
                .Select(
                    a =>
                        new Beer()
                        {
                            AlcoholByVolume = a.Alkoholhalt,
                            AlcoholPerPriceUnit = a.Alkoholhalt/a.PrisPerLiter,
                            Country = a.Ursprunglandnamn,
                            Name = a.Namn,
                            Price = a.Prisinklmoms,
                        })
                .ToArray();
        }

        public IEnumerable<Beer> GetBeersByCharacteristics(SearchCriteria criteria)
        {
            return _beers.Where(b => b.MatchesCriteria(criteria)).Take(3).ToArray();
        }
    }
}
