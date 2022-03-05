using SEO_WebApi.Extentions;
using SEO_WebApi.Helpers;
using SEO_WebApi.Models;
using System.Collections.Generic;

namespace SEO_WebApi.Services
{
    public class GoogleSearch : IGoogleSearch
    {
        private readonly IWebScrapper _webScrapper;
        private readonly IRegexHelper _regexHelper;
        const string GOOGLE_SEARCH_BASE_URL = "https://www.google.com.au/search?num=100&q=";

        private readonly List<string> _blackListed = new List<string>
        {
            "http://www.w3.org/2000/svg"
        };

        public GoogleSearch(IWebScrapper webScrapper, IRegexHelper regexHelper)
        {
            _webScrapper = webScrapper;
            _regexHelper = regexHelper;
        }

        /// <summary>
        /// Perform google search with the given text and fetches all links
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<string> GetAllLinks(string searchText)
        {
            var urlListFromGoogleSearch = new List<string>();

            if (searchText.IsNullOrEmpty())
                return urlListFromGoogleSearch;

            var htmlText = _webScrapper.GetHTMLText(CreateGoogleSearchURL(searchText));

            var cites = _regexHelper.GetAllCiteTags(htmlText);

            foreach (var cite in cites)
                urlListFromGoogleSearch.AddRange(_regexHelper.GetAllUrls(cite));

            urlListFromGoogleSearch.RemoveAll(_blackListed.Contains);

            return urlListFromGoogleSearch;

        }

        /// <summary>
        /// Get ranking of the given url in the google search result og given provided text
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="urlToMatch"></param>
        /// <returns></returns>
        public SearchResult GetURLRanks(string searchText, string urlToMatch)
        {
            var links = GetAllLinks(searchText);

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
