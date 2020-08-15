using System;
using System.Linq;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class Calculator
    {
        private readonly InvertedIndex tokens;

        public Calculator(InvertedIndex tokens)
        {
            this.tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
        }

        public HashSet<string> Calculate(QueryProcessor query)
        {
            var result = new HashSet<string>();

            result = query.AndWords.ListProcess(result, tokens);
            result = query.OrWords.ListProcess(result, tokens);
            result = query.RemoveWords.ListProcess(result, tokens);

            return new HashSet<string>(result);
        }
    }
}