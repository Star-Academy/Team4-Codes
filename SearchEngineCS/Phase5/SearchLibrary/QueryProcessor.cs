using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class QueryProcessor
    {
        IUserInput InputFromUser { get; set; }
        public IKeywordList OrWords { get; set; }
        public IKeywordList AndWords { get; set; }
        public IKeywordList RemoveWords { get; set; }


        public QueryProcessor(IUserInput userInput)
        {
            this.InputFromUser = userInput;
            OrWords = new PlusSignKeyword();
            AndWords = new NoSignKeyword();
            RemoveWords = new MinusSignKeyword();
        }
        public void Process()
        {
            string[] keywords = InputFromUser.ScanInput().Split(" ");
            foreach (string keyword in keywords)
            {
                if (keyword.StartsWith("+"))
                {
                    OrWords.Content.Add(keyword.Substring(1));
                }
                else if (keyword.StartsWith("-"))
                {
                    RemoveWords.Content.Add(keyword.Substring(1));
                }
                else
                {
                    AndWords.Content.Add(keyword);
                }
            }
        }
    }
}