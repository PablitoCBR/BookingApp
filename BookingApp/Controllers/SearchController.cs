using BookingApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        [AllowAnonymous]
        [HttpGet("{businessName}")]
        public IActionResult Get(string businessName)
        {
            return Ok(_searchService.SearchByCompanyName(businessName));
        }
    }
}