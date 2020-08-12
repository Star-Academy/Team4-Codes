using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class QueryProcessor
    {
        IUserInput InputFromUser { get; set; }
        public HashSet<string> OrWords { get; set; }
        public HashSet<string> AndWords { get; set; }
        public HashSet<string> RemoveWords { get; set; }


        public QueryProcessor(IUserInput userInput)
        {
            this.InputFromUser = userInput;
            OrWords = new HashSet<string>();
            AndWords = new HashSet<string>();
            RemoveWords = new HashSet<string>();
        }
        public void Process()
        {
            string[] keywords = InputFromUser.ScanInput().Split(" ");
            foreach (string keyword in keywords)
            {
                if (keyword.StartsWith("+"))
                {
                    OrWords.Add(keyword.Substring(1));
                }
                else if (keyword.StartsWith("-"))
                {
                    RemoveWords.Add(keyword.Substring(1));
                }
                else
                {
                    AndWords.Add(keyword);
                }
            }
        }
    }
}