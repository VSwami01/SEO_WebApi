using System.Collections.Generic;

namespace SEO_WebApi.Helpers
{
    public interface IRegexHelper
    {
        IList<string> GetAllUrls(string text);
    }
}
