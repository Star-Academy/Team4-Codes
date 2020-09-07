using Nest;
using System;

namespace SearchApi
{
    public class ElasticConnectionSettings
    {
        private const string Uri = "http://localhost:9200";

        public static ConnectionSettings GetSettings()
        {
            var uri = new Uri(Uri);
            var connectionSettings = new ConnectionSettings(uri);
#if DEBUG
            connectionSettings.EnableDebugMode();
#endif
            return connectionSettings;
        }
    }
}