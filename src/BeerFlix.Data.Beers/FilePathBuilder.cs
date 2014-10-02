namespace BeerFlix.Data.Beers
{
    public class FilePathBuilder : IFilePathBuilder
    {
        public string BuildPath(string documentName)
        {
            return documentName;
        }
    }
}