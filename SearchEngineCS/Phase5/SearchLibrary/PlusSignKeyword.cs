using System.Collections.Generic;
using System;
using System.Linq;

namespace SearchLibrary
{
    public class PlusSignKeyword : IKeywordList
    {
        public HashSet<string> Content { get; } = new HashSet<string>();
        public HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            var output = new HashSet<string> (result);
            foreach (string word in Content)
            {
                output.UnionWith(tokens.Map[word]);
            }
            return output;
        }
    }
}