using System.Collections.Generic;
using System;
using System.Linq;

namespace SearchLibrary
{
    public class NoSignKeyword : IKeywordList
    {
        public override HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            bool isFirstTime = true;
            if (Content.Count != 0)
            {
                foreach (string word in Content)
                {
                    if (tokens.Map.ContainsKey(word)){
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

                }

            }

            return result;
        }
    }
}