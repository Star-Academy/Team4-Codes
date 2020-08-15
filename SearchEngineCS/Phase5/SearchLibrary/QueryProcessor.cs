using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class QueryProcessor
    {
        private readonly IUserInput inputFromUser;
        public IKeywordList OrWords { get; } = new PlusSignKeyword();
        public IKeywordList AndWords { get; } = new NoSignKeyword();
        public IKeywordList RemoveWords { get; } = new MinusSignKeyword();


        public QueryProcessor(IUserInput userInput)
        {
            this.inputFromUser = userInput;
        }
        public void Process()
        {
            string[] keywords = inputFromUser.ScanInput().Split(" ");
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