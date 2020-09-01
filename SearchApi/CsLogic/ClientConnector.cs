using Nest;
using System;

namespace SearchApi.CsLogic
{
    public class ClientConnector
    {
        private readonly string clientUri = "http://localhost:9200";
        public ElasticClient CreateClient(){
            var uri = new Uri(clientUri);
            var connectionSettings = new ConnectionSettings(uri);
#if DEBUG
            connectionSettings.EnableDebugMode();
#endif
            var client = new ElasticClient(connectionSettings);
            return client;
        }
    }
}