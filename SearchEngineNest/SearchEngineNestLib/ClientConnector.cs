using Nest;
using System;

namespace SearchEngineNestLib
{
    public class ClientConnector
    {
        public ElasticClient CreateClient(){
            var uri = new Uri(Consts.ClientUri);
            var connectionSettings = new ConnectionSettings(uri);
#if DEBUG
            connectionSettings.EnableDebugMode();
#endif
            var client = new ElasticClient(connectionSettings);
            return client;
        }
    }
}