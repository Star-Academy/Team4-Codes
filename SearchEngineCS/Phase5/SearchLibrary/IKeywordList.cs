using System.Collections.Generic;

namespace SearchLibrary
{
    public abstract class IKeywordList
    {
        public HashSet<string> Content { get; } = new HashSet<string>();

        public abstract HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens);
    }
}