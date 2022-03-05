using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEO_WebApi.Models;
using SEO_WebApi.Services;
using System.Collections.Generic;

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
        public SearchResult GetURLRanks(string searchText, string urlToMatch)
        {
            return _googleSearch.GetURLRanks(searchText, urlToMatch);
        }

        [HttpGet("GetAllLinks")]
        public IEnumerable<string> GetAllLinks(string searchText)
        {
            return _googleSearch.GetAllLinks(searchText);
        }
    }
}
