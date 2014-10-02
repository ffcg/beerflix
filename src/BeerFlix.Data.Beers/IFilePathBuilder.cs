namespace BeerFlix.Data.Beers
{
    public interface IFilePathBuilder
    {
        string BuildPath(string documentName);
    }
}