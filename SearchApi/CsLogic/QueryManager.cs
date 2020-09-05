using SearchApi.Models;
using SearchApi.CsLogic;
using System.Collections.Generic;
using Nest;
using System;
using System.Linq;

namespace SearchApi.CsLogic
{
    public class QueryManager
    {

        //sth reeeeealy funny
        private ElasticClient Client;
        private const string IndexName = "english-docs";
        private ISearchResponse<Document> Response { get; set; }
        private Input InputProc;

        public QueryManager(Input inputProcessor)
        {
            InputProc = inputProcessor;
        }

        public IEnumerable<QueryContainer> StringListToQueryList(IEnumerable<string> input)
        {
            return input.Select(word =>
                (QueryContainer)new MatchQuery
                {
                    Field = "content",
                    Query = word
                }
            );
        }

        public void SearchQuery()
        {
            QueryContainer query = new BoolQuery
            {
                Should = new List<QueryContainer> {
                    new BoolQuery{
                        Must = StringListToQueryList(InputProc.AndWords)
                    },
                    new BoolQuery{
                        Should = StringListToQueryList(InputProc.OrWords)
                    }
                },
                MustNot = StringListToQueryList(InputProc.RemoveWords)
            };

            Response = Client.Search<Document>(s => s
                .Index(IndexName)
                .Query(q => query)
                .Size(1000));
        }
        public List<string> QueryResult()
        {
            var output = new List<string>();
            foreach (var hit in Response.Hits)
            {
                output.Add(hit.Source.ToString());
            }
            return output;
        }
    }
}