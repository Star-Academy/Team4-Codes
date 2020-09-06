using SearchApi.Models;
using SearchApi.CsLogic;
using System.Collections.Generic;

namespace SearchApi.Services.InputSearch
{
    public class InputService : IInputService
    {
        IQueryManager QueryManager;

        public InputService(IQueryManager queryManager){
            QueryManager = queryManager;
        }
        
        public IEnumerable<string> SearchResult(Input input)
        {
            input.Process();
            QueryManager.SearchQuery(input);
            return QueryManager.QueryResult();
        }
    }
}