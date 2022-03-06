using SEO_WebApi.Extentions;
using SEO_WebApi.Helpers;
using SEO_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEO_WebApi.Services
{
    public class GoogleSearch : IGoogleSearch
    {       
        private const string GOOGLE_SEARCH_BASE_URL = "https://www.google.com.au/search?num=100&q=";
        private readonly IWebScrapper _webScrapper;
        private readonly IHtmlHelper _htmlHelper;
  
        private readonly List<string> _blackListed = new List<string>
        {
            "http://www.w3.org/2000/svg"
        };

        public GoogleSearch(IWebScrapper webScrapper, IRegexHelper regexHelper, IHtmlHelper htmlHelper)
        {
            _webScrapper = webScrapper;
            _htmlHelper = htmlHelper;
        }

        /// <summary>
        /// Perform google search with the given text and fetches all links
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetAllLinksAsync(string searchText)
        {
            var urlListFromGoogleSearch = new List<string>();

            if (searchText.IsNullOrEmpty())
                return urlListFromGoogleSearch;

            var htmlText = await _webScrapper.GetHTMLText(CreateGoogleSearchURL(searchText));

            urlListFromGoogleSearch.AddRange(_htmlHelper.GetLinksInsideAllCiteTags(htmlText));

            urlListFromGoogleSearch.RemoveAll(_blackListed.Contains);

            return urlListFromGoogleSearch;

        }

        /// <summary>
        /// Get ranking of the given url in the google search result og given provided text
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="urlToMatch"></param>
        /// <returns></returns>
        public async Task<SearchResult> GetURLRanksAsync(string searchText, string urlToMatch)
        {
            var links = await GetAllLinksAsync(searchText);

            return new SearchResult()
            {
                SearchText = searchText,
                UrlToMatch = urlToMatch,
                Rankings = links.FindAllIndexOffsetOne(urlToMatch.TrimSpecialChars())
            };
        }

        /// <summary>
        /// Create a Google search url using the search text
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        private string CreateGoogleSearchURL(string searchStr)
        {
            var search = new List<string>();

            foreach (var str in searchStr.Split(' '))
                search.Add(str.TrimSpecialChars());

            return GOOGLE_SEARCH_BASE_URL + string.Join('+', search.ToArray()); 
        }

    }
}
