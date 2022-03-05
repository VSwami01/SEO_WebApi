using SEO_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEO_WebApi.Services
{
    public interface IGoogleSearch
    {
        IEnumerable<string> GetAllLinks(string searchText);
        SearchResult GetURLRanks(string searchText, string urlToMatch);
    }
}
