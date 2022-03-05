using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEO_WebApi.Models;
using SEO_WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEO_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IGoogleSearch _googleSearch;

        public SearchController(ILogger<SearchController> logger, IGoogleSearch googleSearch)
        {
            _logger = logger;
            _googleSearch = googleSearch;
        }

        [HttpGet("GetURLRanks")]
        public async Task<SearchResult> GetURLRanks(string searchText, string urlToMatch)
        {
            return await _googleSearch.GetURLRanksAsync(searchText, urlToMatch);
        }

        [HttpGet("GetAllLinks")]
        public async Task<IEnumerable<string>> GetAllLinks(string searchText)
        {
            return await _googleSearch.GetAllLinksAsync(searchText);
        }
    }
}
