using System.Threading.Tasks;

namespace SEO_WebApi.Helpers
{
    public interface IWebScrapper
    {
        Task<string> GetHTMLText(string url);
    }
}
