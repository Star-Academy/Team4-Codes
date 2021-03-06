using Nest;
using SearchEngineNestLib.Models;

namespace SearchEngineNestLib
{
    public class IndexManager
    {
        private const string MyAnalizer = "myAnalizer";
        private IResponse Response;

        private IPromise<IIndexSettings> CreateSettings(IndexSettingsDescriptor settingsDescriptor)
        {
            return settingsDescriptor
                .Analysis(analysis => analysis
                    .Analyzers(analyzer => analyzer
                        .Custom(MyAnalizer, custom => custom
                            .Tokenizer(Consts.StandardTokenizer)
                            .Filters(Consts.LowercaseFilter)
                        )
                    )
                );
        }

        private ITypeMapping CreateMapping(TypeMappingDescriptor<Document> mappingDescriptor)
        {
            return mappingDescriptor
                .Properties(prp => prp
                    .Keyword(t => t
                        .Name(n => n.Id)
                    )
                    .Text(t => t
                        .Name(n => n.Content)
                        .Analyzer(MyAnalizer)
                    )
                );
        }
        public void CreateIndex(ElasticClient client, string indexName)
        {
            Response = client.Indices.Create(indexName,
                s => s
                    .Settings(CreateSettings)
                    .Map<Document>(CreateMapping)
            );
        }

        public void EvaluateResponse(){
            var responseValidator = new ResponseValidator(Response);
            responseValidator.Evaluate();
        }

        public void DeleteIndex(ElasticClient client, string indexName)
        {
            var deleteResponse = client.Indices.Delete(indexName);
        }
    }
}