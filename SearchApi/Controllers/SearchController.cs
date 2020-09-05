using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SearchApi.Models;
using SearchApi.CsLogic;
using SearchApi.Services.InputSearch;

namespace SearchApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IInputService inputService;
        public SearchController(IInputService inputService)
        {
            _inputService = inputService;
        }

        [HttpPost]
        public IActionResult InputUser(Input userInput)
        {
            return Ok(_inputService.SearchResult(userInput));
        }
    }
}