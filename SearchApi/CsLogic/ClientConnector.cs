using Nest;
using System;
namespace SearchApi.CsLogic

{
    public class ClientConnector
    {
        public ElasticClient CreateClient(){
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
#if DEBUG
            connectionSettings.EnableDebugMode();
#endif
            var client = new ElasticClient(connectionSettings);
            return client;
        }
    }
}