using System;
using Nest;
using ElasticLib.Models;
using System.Collections.Generic;

namespace ElasticLib
{
    public class App
    {

        private const string IndexName = "index2";
        private const string Path = "..\\Resources\\people.json";
        public void Start()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            // DebugMode gives you the request in each request to make debuging easier
            // But don't forget to only use it in debugging, because its usage has some overhead
            // and should not be used in production
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            // var response = client.Ping();
            // Console.WriteLine(response);

            var response = client.Indices.Create(IndexName,
                    s => s.Settings(settings => settings
                        .Setting("max_ngram_diff", 7)
                        .Analysis(analysis => analysis
                            .TokenFilters(tf => tf
                                .NGram("myNgramFilter", ng => ng
                                    .MinGram(3)
                                    .MaxGram(10)))
                            .Analyzers(analyzer => analyzer
                                .Custom("myNgramAnalyzer", custom => custom
                                    .Tokenizer("standard")
                                    .Filters("lowercase", "myNgramFilter")
                                )
                            )
                        )
                    )
                    .Map<Person>(m => m
                        .Properties(prp => prp
                            .AddAboutFieldMapping()
                            .AddAgeFieldMapping()
                            .AddEyeColorFieldMapping()
                            .AddNameFieldMapping()
                            .AddGenderFieldMapping()
                            .AddCompanyFieldMapping()
                            .AddEmailFieldMapping()
                            .AddPhoneFieldMapping()
                            .AddAddressFieldMapping()
                            .AddRegistrationDateFieldMapping()
                            .AddLocationFieldMapping()
                        )
                    )
            );

            var pr = new PeopleReader();
            var people = pr.Read(Path);

            var bulkDescriptor = new BulkDescriptor();
            foreach (var person in people)
            {
                bulkDescriptor.Index<Person>(x => x
                    .Index(IndexName)
                    .Document(person)
                );
            }
            client.Bulk(bulkDescriptor);

            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "name",
                        Query = "Deanne Garrison"
                    }
                }
            };

            var r = client.Search<Dictionary<string, object>>(s => s
                .Index(IndexName)
                .Query(q => query));

            Console.WriteLine(r);
        }
    }
}