using System.Collections.Generic;

namespace SearchLibrary
{
    public interface IKeywordList
    {
        HashSet<string> Content { get; }

        HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens);
    }
}