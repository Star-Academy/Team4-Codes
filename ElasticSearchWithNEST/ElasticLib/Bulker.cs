using Nest;
using ElasticLib.Models;
using System.Collections.Generic;

namespace ElasticLib
{
    public class Bulker
    {
        public void Bulk(ElasticClient client, string indexName, List<Person> documents){
            var bulkDescriptor = new BulkDescriptor();
            foreach (var person in documents)
            {
                bulkDescriptor.Index<Person>(x => x
                    .Index(indexName)
                    .Document(person)
                );
            }
            client.Bulk(bulkDescriptor);
        }
    }
}