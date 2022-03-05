using System.Collections.Generic;

namespace SEO_WebApi.Models
{
    /// <summary>
    /// Store the result of url search including Rankings
    /// </summary>
    public class SearchResult
    {
        public string SearchText { get; set; }
        public string UrlToMatch { get; set; }
        public IList<int> Rankings { get; set; }
        public int TotalAppearence => Rankings.Count;
    }
}
