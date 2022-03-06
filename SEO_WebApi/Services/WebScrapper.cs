using SEO_WebApi.Extentions;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEO_WebApi.Services
{
    public class WebScrapper : IWebScrapper
    {
        /// <summary>
        /// Get all html of the given url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<string> GetHTMLText(string url)
        {
            if (url.IsNullOrEmpty())
                return Task.FromResult(string.Empty);

            using (HttpClient client = new HttpClient())
            {
                // changing user-agent to something that Chrome uses. This gets the complete html along with <cite> tags
                // https://stackoverflow.com/questions/53601463/why-does-the-html-downloaded-by-webclient-differ-from-chromes-view-source-pag
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        return content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
