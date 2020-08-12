using System.Collections.Generic;
using System;
namespace SearchLibrary
{
    public class NoSignKeyword : IKeywordList
    {
        public override HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            bool isFirstTime = true;
            foreach (string word in Content)
            {
                if (!isFirstTime)
                {
                    result.IntersectWith(tokens.Map[word]);
                }
                else
                {
                    result.UnionWith(tokens.Map[word]);
                    isFirstTime = false;
                }
            }
            return result;
        }
    }
}