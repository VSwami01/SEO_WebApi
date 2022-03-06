using SEO_WebApi.Constants;
using SEO_WebApi.Extentions;
using System.Collections.Generic;

namespace SEO_WebApi.Helpers
{
    public class HtmlHelper : IHtmlHelper
    {
        IRegexHelper _regexHelper;
        public HtmlHelper (IRegexHelper regexHelper)
        {
            _regexHelper = regexHelper;
        }

        /// <summary>
        /// Get all occurance of an html tags in a given html text
        /// </summary>
        /// <param name="htmlText"></param>
        /// <param name="htmlTag"></param>
        /// <returns></returns>
        public IList<string> GetAllTags(string htmlText, string htmlTag)
        {
            var matchedTags = new List<string>();

            if (htmlText.IsNullOrEmpty() || htmlTag.IsNullOrEmpty())
                return matchedTags;

            string startTag = string.Format("<{0}", htmlTag);
            string endTag = string.Format("</{0}>", htmlTag);

            int startIndex = htmlText.IndexOf(startTag);
            int endIndex;

            while (startIndex >= 0)
            {
                endIndex = htmlText.IndexOf(endTag, startIndex);

                if (endIndex < 0)
                    break;

                matchedTags.Add(htmlText.Substring(startIndex, (endIndex - startIndex + endTag.Length)));

                startIndex = htmlText.IndexOf(startTag, endIndex + endTag.Length);
            }

            return matchedTags;
        }

        /// <summary>
        /// Get all links that are inside cite html tag
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public IList<string> GetLinksInsideAllCiteTags(string htmlText)
        {
            var linksInsideCiteTags = new List<string>();

            if (htmlText.IsNullOrEmpty())
                return linksInsideCiteTags;

            var cites = GetAllTags(htmlText, HtmlTags.CITE);

            foreach (var cite in cites)
            {
                foreach (var newUrl in _regexHelper.GetAllUrls(cite))
                {
                    if (linksInsideCiteTags.FindIndex(url => url == newUrl) < 0)
                        linksInsideCiteTags.Add(newUrl);
                }
            }
            return linksInsideCiteTags;
        }
    }
}
