using System.Collections.Generic;

namespace SEO_WebApi.Helpers
{
    public interface IHtmlHelper
    {
        IList<string> GetAllTags(string htmlText, string htmlTag);
        IList<string> GetLinksInsideAllCiteTags(string htmlText);
    }
}
