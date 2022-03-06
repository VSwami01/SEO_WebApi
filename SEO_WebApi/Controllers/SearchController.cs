using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEO_WebApi.Services;
using System;
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
        public async Task<IActionResult> GetURLRanks(string searchText, string urlToMatch)
        {
            try
            {
                return Ok(await _googleSearch.GetURLRanksAsync(searchText, urlToMatch));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetURLRanks action: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAllLinks")]
        public async Task<IActionResult> GetAllLinks(string searchText)
        {
            try
            {
                return Ok(await _googleSearch.GetAllLinksAsync(searchText));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllLinks action: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
