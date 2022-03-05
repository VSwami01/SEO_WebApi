using SEO_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEO_WebApi.Services
{
    public interface IGoogleSearch
    {
        Task<IEnumerable<string>> GetAllLinksAsync(string searchText);
        Task<SearchResult> GetURLRanksAsync(string searchText, string urlToMatch);
    }
}
