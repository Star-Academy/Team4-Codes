using Nest;
using System;
namespace SearchEngineNestLib
{
    public class App
    {
        public string IndexName = "english-docs";
        private const string Path = "..\\EnglishData";

        private void CreateAndInitIndexByPath(string indexName, string path){
            var indexManager = new IndexManager();
            if (!client.Indices.Exists(IndexName).Exists)
            {
                indexManager.CreateIndex(client, IndexName);
                indexManager.EvaluateResponse();
                var docReader = new DocReader();
                var docs = docReader.ReadAll(Path);
                var bulker = new Bulker();
                bulker.Bulk(client, IndexName, docs);
            }
            client.Indices.Refresh(IndexName);
        }
        public void Start()
        {
            var client = new ClientConnector().CreateClient();

            CreateAndInitIndexByPath(IndexName, Path);

            var inputProc = new InputProcessor(new ConsoleInput());
            inputProc.Process();

            var queryManager = new QueryManager(client, IndexName, inputProc);
            queryManager.SearchQuery();

            var responseValidator = new ResponseValidator(queryManager.Response);
            responseValidator.Evaluate();

            queryManager.ShowResult();
        }
    }
}