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

        public QueryManager(ElasticClient client, string indexName)
        {
            this.Client = client;
            this.IndexName = indexName;
        }
        public void BoolAndMatchSample(List<string> mamad)
        {
            foreach(string val in mamad){
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "content",
                        Query = "hello"
                    }
                }
            };

            Response = Client.Search<Document>(s => s
                .Index(IndexName)
                .Query(q => query));
            }
        }
        public void ShowResult()
        {
            foreach (var iHit in Response.Hits)
            {
                Console.WriteLine(iHit.Source);
            }
        }
    }
}