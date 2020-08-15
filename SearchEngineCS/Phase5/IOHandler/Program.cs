using System;
using SearchLibrary;

namespace IOHandler
{

    class Program
    {
        private const string EnglishDataDirectory = ".\\EnglishData";

        static void Main(string[] args)
        {
            var app = new SearchApp(EnglishDataDirectory);
            app.Start();
        }
    }
}
