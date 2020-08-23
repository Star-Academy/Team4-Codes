using Nest;
using System;

namespace SearchEngineNestLib
{
    public class ClientConnector
    {
        public ElasticClient CreateClient(){
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            return client;
        }
    }
}