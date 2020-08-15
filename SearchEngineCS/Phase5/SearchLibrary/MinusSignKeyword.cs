using System.Collections.Generic;
using System;
using System.Linq;
namespace SearchLibrary
{
    public class MinusSignKeyword : IKeywordList
    {
        public override HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            var output = result;
            foreach (string word in Content)
            {
                foreach(string id in tokens.Map[word])
                output.Remove(id);
            }
            return output;
        }
    }
}