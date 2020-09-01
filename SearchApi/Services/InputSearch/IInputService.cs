using System.Collections.Generic;
using SearchApi.Models;
namespace SearchApi.Services.InputSearch
{
    public interface IInputService
    {
        List<string> SearchResult(Input input);
    }
}