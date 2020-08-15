using System;
using SearchLibrary;

namespace IOHandler
{

    class Program
    {
        private const string EnglishDataDirectory = "..\\EnglishData";

        static void Main(string[] args)
        {
            var fReader = new FileReader();
            var inverted = new InvertedIndex();
            var data = fReader.ReadAll(EnglishDataDirectory);
            inverted.FillMap(data);

            var calculator = new Calculator(inverted);

            while (true)
            {
                var input = new ConsoleInput();
                var queryProcessor = new QueryProcessor(input);
                queryProcessor.Process();
                
                var result = calculator.Calculate(queryProcessor);

                foreach (string id in result)
                {
                    Console.Write(id + " ");
                }
            }
        }
    }
}
