using System;
using System.Collections.Generic;
using Nest;
using ElasticLib.Models;

namespace ElasticLib
{
    public class IndexManager
    {
        
        public void CreateIndex(ElasticClient client, string indexName){
            var response = client.Indices.Create(indexName,
                    s => s.Settings(settings => settings
                        .Setting("max_ngram_diff", 8)
                        .Analysis(analysis => analysis
                            .TokenFilters(tf => tf
                                .NGram("myNgramFilter", ng => ng
                                    .MinGram(7)
                                    .MaxGram(15)))
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
        }

        public void DeleteIndex(ElasticClient client, string indexName){
            var deleteRespones = client.Indices.Delete(indexName);
        }
    }
}