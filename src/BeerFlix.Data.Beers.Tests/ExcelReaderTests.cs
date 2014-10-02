using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace BeerFlix.Data.Beers.Tests
{
    public class ExcelReaderTests
    {
        [Test]
        public void ExcelReader_should_read_Systembolaget_excel_and_return_all_rows()
        {
            // Arrange
            var reader = new ExcelReader<SystembolagetArticleRow>();
            var fileStream = File.Open(@"Data/systembolaget.xlsx",
                FileMode.Open, FileAccess.Read, FileShare.Read);

            // Act
            var systembolagetArticleRows = reader.GetAllRows(fileStream, @"AllaArtiklar");

            // Assert
            systembolagetArticleRows.Should().HaveCount(2049);
        }
    }
}