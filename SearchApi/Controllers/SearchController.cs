using Microsoft.AspNetCore.Mvc;
using SearchApi.Models;
using SearchApi.CsLogic;
using SearchApi.Services.InputSearch;

namespace SearchApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IInputService InputService;
        public SearchController(IInputService inputService)
        {
            InputService = inputService;
        }

        [HttpPost]
        public IActionResult InputUser(Input userInput)
        {
            return Ok(InputService.SearchResult(userInput));
        }
    }
}