using SEO_WebApi.Extentions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SEO_WebApi.Helpers
{
    public class RegexHelper : IRegexHelper
    {
        const string REGEX_URL = @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)";

        /// <summary>
        /// Apply regex to get all urls from the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public IList<string> GetAllUrls(string text)
        {
            return GetAllMatch(text, REGEX_URL);
        }

        /// <summary>
        /// Apply regex to the string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regexPattern"></param>
        /// <returns></returns>
        private IList<string> GetAllMatch(string text, string regexPattern)
        {
            var matches = new List<string>();

            if(text.IsNullOrEmpty() || regexPattern.IsNullOrEmpty())
            {
                return matches;
            }

            var matchCollection = Regex.Matches(text, regexPattern, RegexOptions.Multiline);

            foreach (Match match in matchCollection)
            {
                if (matches.FindIndex(item => item == match.Value) < 0)
                    matches.Add(match.Value);
            }

            return matches;
        }
    }
}
