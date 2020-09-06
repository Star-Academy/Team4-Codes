using Microsoft.AspNetCore.Mvc;
using SearchApi.Models;
using SearchApi.CsLogic;
using Microsoft.AspNetCore.Cors;
using SearchApi.Services.InputSearch;

namespace SearchApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAllOrigin")]
    public class SearchController : ControllerBase
    {
        private readonly IInputService inputService;
        public SearchController(IInputService inputService)
        {
            this.inputService = inputService;
        }

        [HttpPost]
        public IActionResult InputUser(Input userInput)
        {
            return Ok(inputService.SearchResult(userInput));
        }
    }
}