using System.Collections.Generic;
using System;
using System.Linq;

namespace SearchLibrary
{
    public class PlusSignKeyword : IKeywordList
    {
        public override HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            var output = result;
            foreach (string word in Content)
            {
                output.UnionWith(tokens.Map[word]);
            }
            return output;
        }
    }
}