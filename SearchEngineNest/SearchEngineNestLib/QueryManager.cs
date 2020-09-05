using SearchEngineNestLib.Models;
using System.Collections.Generic;
using Nest;
using System;
using System.Linq;

namespace SearchEngineNestLib
{

    public class QueryManager
    {
        private ElasticClient Client;
        private string IndexName;
        public ISearchResponse<Document> Response { get; set; }
        public InputProcessor InputProc;

        public QueryManager(ElasticClient client, string indexName, InputProcessor inputProcessor)
        {
            Client = client;
            IndexName = indexName;
            InputProc = inputProcessor;
        }

        public IEnumerable<QueryContainer> StringListToQueryList(IEnumerable<string> input)
        {
            return input.Select(word =>
                (QueryContainer) new MatchQuery
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
        public void ShowResult()
        {
            Console.WriteLine(Consts.ResultMessage, Response.Hits.Count);
            foreach (var hit in Response.Hits)
            {
                Console.Write(hit.Source + Consts.ResultSplitter);
            }
        }
    }
}