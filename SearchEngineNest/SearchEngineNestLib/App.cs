namespace SearchEngineNestLib
{
    public class App
    {
        public string IndexName = "EnglishDocs";
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

            var queryManager = new QueryManager(client, IndexName);
            
            queryManager.BoolAndMatchSample();
            queryManager.ShowResult();

            //indexManager.DeleteIndex(client, IndexName);

        }
    }
}