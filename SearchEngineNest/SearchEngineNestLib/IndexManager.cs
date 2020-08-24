using Nest;
using System.Collections.Generic;
using SearchEngineNestLib.Models;
using System;
namespace SearchEngineNestLib
{
    public class IndexManager
    {
        private const string MyAnalizer = "myAnalizer";
        private IResponse Response;
        public void CreateIndex(ElasticClient client, string indexName)
        {
            Response = client.Indices.Create(indexName,
                    s => s.Settings(settings => settings
                        .Analysis(analysis => analysis
                            .Analyzers(analyzer => analyzer
                                .Custom(MyAnalizer, custom => custom
                                    .Tokenizer("standard")
                                    .Filters("lowercase")
                                )
                            )
                        )
                    )
                    .Map<Document>(m => m
                        .Properties(prp => prp
                            .Keyword(t => t
                                .Name(n => n.ID)
                            )
                            .Text(t => t
                                .Name(n => n.Content)
                                .Analyzer(MyAnalizer)
                            )
                        )
                    )
            );
        }

        public void EvaluateResponse(){
            var responseValidator = new ResponseValidator(Response);
            responseValidator.Evaluate();
        }

        public void DeleteIndex(ElasticClient client, string indexName)
        {
            var deleteRespones = client.Indices.Delete(indexName);
        }
    }
}