using System.Collections.Generic;
using System;
using System.Linq;
namespace SearchLibrary
{
    public class MinusSignKeyword : IKeywordList
    {
        public HashSet<string> Content { get; } = new HashSet<string>();
        public HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            var output = new HashSet<string>(result);
            foreach (string word in Content)
            {
                foreach (string id in tokens.Map[word])
                    output.Remove(id);
            }
            return output;
        }
    }
}