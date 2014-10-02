namespace BeerFlix.Web.Common.Http
{
    public interface IHtmlDecoder
    {
        string Decode(string encodedString);
    }
}