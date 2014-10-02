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
            var reader = new ExcelReader<SystembolagetArticleRow>(new FilePathBuilder(), @"Data/systembolaget.xlsx", @"AllaArtiklar");

            // Act
            var systembolagetArticleRows = reader.GetAllRows();

            // Assert
            systembolagetArticleRows.Should().HaveCount(2048);
        }
    }
}