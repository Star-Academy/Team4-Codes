using System.Collections.Generic;
using System;
namespace SearchLibrary
{
    public class PlusSignKeyword : IKeywordList
    {
        public override HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            foreach (string word in Content)
            {
                result.UnionWith(tokens.Map[word]);
            }
            return result;
        }
    }
}