using SearchEngineNestLib.Models;
using System.Collections.Generic;
using Nest;
using System;

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
            this.Client = client;
            this.IndexName = indexName;
            this.InputProc = inputProcessor;
        }

        public List<QueryContainer> StringListToQueryList(List<string> input){
            var output = new List<QueryContainer>();
            foreach(var word in input){
                output.Add(
                    new MatchQuery
                    {
                        Field = "content",
                        Query = word
                    }
                );
            }
            return output;
        }

        public void SearchQuerry()
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
            Console.WriteLine("{0} Results Found: ",Response.Hits.Count);
            foreach (var iHit in Response.Hits)
            {
                Console.Write(iHit.Source + " ");
            }
            Console.WriteLine("");
        }
    }
}