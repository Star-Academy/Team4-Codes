using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class Calculator
    {
        InvertedIndex Tokens { get; set; }
        HashSet<string> Result;

        public Calculator(InvertedIndex tokens)
        {
            this.Tokens = tokens;
            Result = new HashSet<string>();
        }
        public void Calculate(QueryProcessor query)
        {
            query.AndWords.ListProcess(Result, Tokens);
            query.OrWords.ListProcess(Result, Tokens);
            query.RemoveWords.ListProcess(Result, Tokens);
        }
    }
}