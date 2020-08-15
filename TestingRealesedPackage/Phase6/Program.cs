using System;
using SearchLibrary;
namespace Phase6
{
    class Program
    {
        private const string EnglishDataDirectory = "..\\..\\SearchEngineCS\\Phase5\\EnglishData";
        static void Main(string[] args)
        {
            var app = new SearchApp(EnglishDataDirectory);
            app.Start();
        }
    }
}
