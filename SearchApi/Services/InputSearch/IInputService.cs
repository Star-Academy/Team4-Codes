using System.Collections.Generic;
using SearchApi.Models;

namespace SearchApi.Services.InputSearch
{
    public interface IInputService
    {
        IEnumerable<string> SearchResult(Input input);
    }
}