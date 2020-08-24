using Nest;
using System;
namespace SearchEngineNestLib
{
    public class App
    {
        public string IndexName = "english-docs";
        private const string Path = "..\\EnglishData";
        public void Start()
        {
            

            var clientCreator = new ClientConnector();
            var client = clientCreator.CreateClient();

            var indexManager = new IndexManager();
            indexManager.CreateIndex(client, IndexName);

            var docReader = new DocReader();
            var docs = docReader.ReadAll(Path);

            var bulker = new Bulker();
            bulker.Bulk(client, IndexName, docs);

            client.Indices.Refresh(IndexName);

            var stringInput = new ConsoleInput();

            var inputProc = new InputProcessor(stringInput);
            inputProc.Process();

            var queryManager = new QueryManager(client, IndexName, inputProc);
            queryManager.SearchQuerry();
            queryManager.ShowResult();
            
            indexManager.DeleteIndex(client, IndexName);

        }
    }
}