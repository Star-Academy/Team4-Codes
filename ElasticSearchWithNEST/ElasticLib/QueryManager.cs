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
        public ISearchResponse<Person> Response { get; set; }

        public QueryManager(ElasticClient client, string indexName)
        {
            this.Client = client;
            this.IndexName = indexName;
        }
        public void BoolAndMatchSample()
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

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void RangeSample()
        {
            QueryContainer query = new LongRangeQuery
            {
                Boost = 1.1,
                Field = "age",
                GreaterThan = 20,
                LessThan = 30,
                Relation = RangeRelation.Within
            };

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void FuzzySample()
        {
            QueryContainer query = new FuzzyQuery
            {
                Boost = 1.1,
                Field = "company",
                Fuzziness = Fuzziness.Auto,
                Value = "buzzness",
                MaxExpansions = 100,
                PrefixLength = 3,
                Rewrite = MultiTermQueryRewrite.ConstantScore,
                Transpositions = true
            };

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void TermSample()
        {
            QueryContainer query = new TermQuery
            {
                Boost = 1.1,
                Field = "eyeColor",
                Value = "brown"
            };

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void TermsSample()
        {
            QueryContainer query = new TermsQuery
            {
                Boost = 1.1,
                Field = "eyeColor",
                Terms = new List<string> { "blue", "brown" }
            };

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void MultiMatchSample()
        {
            QueryContainer query = new MultiMatchQuery
            {
                Fields = new[] { "name", "email" },
                Query = "deanne",
                Analyzer = "standard",
                Operator = Operator.Or,
                MinimumShouldMatch = 2,
                FuzzyRewrite = MultiTermQueryRewrite.ConstantScoreBoolean,
                AutoGenerateSynonymsPhraseQuery = false
            };

            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => query));
        }

        public void GeoQuery()
        {
            QueryContainer geoQuery = new GeoDistanceQuery
            {
                Field = "location",
                DistanceType = GeoDistanceType.Arc,
                Location = new GeoLocation(-21, -148),
                Distance = "100km"
            };
            Response = Client.Search<Person>(s => s
                .Index(IndexName)
                .Query(q => geoQuery));
        }

        public void AggregationSample(){
            
            Response = Client.Search<Person>(a => a
                .Index(IndexName)
                .Size(0)
                .Aggregations(agg => agg
                    .Terms("eyeColor", c => c
                        .Field(f => f.EyeColor)
                        .Size(int.MaxValue)
                    )
                )
            );
        }

        public void AggregationsSampleResult(){
            var eyeColors = Response.Aggregations.Terms("eyeColor").Buckets;
            foreach(var sth in eyeColors){
                Console.WriteLine("{0}: {1}", sth.Key, sth.DocCount);
            }
        }
        public void ShowResult()
        {
            foreach (var hit in Response.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }
    }
}