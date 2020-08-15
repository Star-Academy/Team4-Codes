using System.Collections.Generic;

namespace SearchLibrary
{
    public interface IKeywordList
    {
        public HashSet<string> Content { get; }

        public abstract HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens);
    }
}