using System;
using System.Collections.Generic;
using Nest;
using ElasticLib.Models;

namespace ElasticLib
{
    public class IndexManager
    {
        private const string MyNgramFilter = "myNgramFilter";
        private const string MyNgramAnalyzer = "myNgramAnalyzer";
        
        private IPromise<IIndexSettings> CreateSettings(IndexSettingsDescriptor settingsDescriptor)
        {
            return settingsDescriptor
                .Setting("max_ngram_diff", 8)
                .Analysis(analysis => analysis
                    .TokenFilters(tf => tf
                        .NGram(MyNgramFilter, ng => ng
                            .MinGram(7)
                            .MaxGram(15)))
                    .Analyzers(analyzer => analyzer
                        .Custom(MyNgramAnalyzer, custom => custom
                            .Tokenizer("standard")
                            .Filters("lowercase", MyNgramFilter)
                        )
                    )
                );
        }

        private ITypeMapping CreateMapping(TypeMappingDescriptor<Person> mappingDescriptor)
        {
            return mappingDescriptor
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
                );
        }
        public void CreateIndex(ElasticClient client, string indexName)
        {
            var response = client.Indices.Create(indexName,
                    s => s
                    .Settings(CreateSettings)
                    .Map<Person>(CreateMapping)
            );
        }

        public void DeleteIndex(ElasticClient client, string indexName)
        {
            var deleteRespones = client.Indices.Delete(indexName);
        }
    }
}