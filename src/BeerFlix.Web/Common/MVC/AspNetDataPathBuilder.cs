using System.Web;
using BeerFlix.Data.Beers;

namespace BeerFlix.Web.Common.MVC
{
    public class AspNetDataPathBuilder : IFilePathBuilder
    {
        public string BuildPath(string documentName)
        {
            var path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", documentName.Replace("Data/", "")));
            return path;
        }
    }
}