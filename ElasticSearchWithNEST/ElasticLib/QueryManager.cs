using System;
using Nest;
using System.Collections.Generic;
using ElasticLib.Models;

namespace ElasticLib
{
    public class QueryManager
    {
        private ElasticClient Client;
        private string IndexName;
        public ISearchResponse<Dictionary<string, object>> Response { get; set; }

        public QueryManager(ElasticClient client, string indexName)
        {
            this.Client = client;
            this.IndexName = indexName;
        }
        public void SampleQuery1()
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "name.ngram",
                        Query = "Deanne Garrison"
                    }
                }
            };

            Response = Client.Search<Dictionary<string, object>>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void ShowResult()
        {
            foreach (var iHit in Response.Hits)
            {
                foreach (var key in iHit.Source.Keys)
                {
                    Console.WriteLine("{0} {1}", key, iHit.Source[key]);
                }
                Console.WriteLine("here");
            }
        }
    }
}