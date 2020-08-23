using System;
using Nest;
using ElasticLib.Models;
using System.Collections.Generic;

namespace ElasticLib
{
    public class App
    {
        public string IndexName = "index5";
        private const string Path = "..\\Resources\\people.json";
        public void Start()
        {
            var clientCreator = new ClientConnector();
            var client = clientCreator.CreateClient();

            var indexManager = new IndexManager();
            indexManager.CreateIndex(client, IndexName);

            var peopleReader = new PeopleReader();
            var people = peopleReader.Read(Path);

            var bulker = new Bulker();
            bulker.Bulk(client, IndexName, people);

            var chert = client.Indices.Refresh(IndexName);

            var queryManager = new QueryManager(client, IndexName);
            
            queryManager.TermsSample();
            //queryManager.ShowResult();

            var validator = new ResponseValidator(queryManager.Response);
            validator.Evaluate();

            indexManager.DeleteIndex(client, IndexName);
            
        }
    }
}