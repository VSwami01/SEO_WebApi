using System.Threading.Tasks;

namespace SEO_WebApi.Services
{
    public interface IWebScrapper
    {
        Task<string> GetHTMLText(string url);
    }
}
