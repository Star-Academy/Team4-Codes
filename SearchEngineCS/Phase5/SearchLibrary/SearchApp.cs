using System;

namespace SearchLibrary
{
    public class SearchApp
    {
        private string dataDirectory {get; set; } = ".\\EnglishData";
        public SearchApp(string directory){
            this.dataDirectory = directory;
        }
        public SearchApp() {}

        public void Start(){
            var fReader = new FileReader();
            var inverted = new InvertedIndex();
            var data = fReader.ReadAll(dataDirectory);
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