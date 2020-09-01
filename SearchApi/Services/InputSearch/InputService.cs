using SearchApi.Models;
using SearchApi.CsLogic;
using System.Collections.Generic;

namespace SearchApi.Services.InputSearch
{
    public class InputService : IInputService
    {
        public List<string> SearchResult(Input input)
        {
            input.Process();
            var query = new QueryManager(input);
            query.SearchQuery();
            return query.QueryResult();
        }
    }
}