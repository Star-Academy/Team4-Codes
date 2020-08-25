using Nest;
using System.Collections.Generic;
using SearchEngineNestLib.Models;

namespace SearchEngineNestLib
{
    public class Bulker
    {
        public void Bulk(ElasticClient client, string indexName, List<Document> documents)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var document in documents)
            {
                bulkDescriptor.Index<Document>(x => x
                    .Index(indexName)
                    .Document(document)
                );
            }
            client.Bulk(bulkDescriptor);
        }

    }
}