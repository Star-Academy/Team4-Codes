using System;
using Nest;
using ElasticLib.Models;
using System.Collections.Generic;

namespace ElasticLib
{
    public class ClientConnector
    {
        
        public ElasticClient CreateClient()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
#if DEBUG
            connectionSettings.EnableDebugMode();
#endif
            var client = new ElasticClient(connectionSettings);
            var response = client.Ping();
            Console.WriteLine(response);
            return client;
        }
    }
}