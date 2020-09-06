using System.Collections.Generic;
using Nest;
using SearchApi.Models;

namespace SearchApi.CsLogic
{
    public interface IQueryManager
    {

        IEnumerable<QueryContainer> StringListToQueryList(IEnumerable<string> input);
        void SearchQuery(Input input);
        List<string> QueryResult();
    }
}