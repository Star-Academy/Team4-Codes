using System.Collections.Generic;
using System;
using System.Linq;

namespace SearchLibrary
{
    public class NoSignKeyword : IKeywordList
    {
        public HashSet<string> Content { get; } = new HashSet<string>();
        public HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens)
        {
            var output = new HashSet<string>(result);

            bool isFirstTime = true;
            if (Content.Count != 0)
            {
                foreach (string word in Content)
                {
                    if (tokens.Map.ContainsKey(word))
                    {
                        if (!isFirstTime)
                        {
                            output.IntersectWith(tokens.Map[word]);
                        }
                        else
                        {
                            output.UnionWith(tokens.Map[word]);
                            isFirstTime = false;
                        }
                    }

                }

            }

            return output;
        }
    }
}