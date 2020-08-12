using System;
using SearchLibrary;
namespace IOHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput input = new ConsoleInput();
            input.ScanInput();

            var queryProcessor = new QueryProcessor(input);
            queryProcessor.Process();

            
        }
    }
}
