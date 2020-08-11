using System.Collections.Generic;

namespace SearchLibrary
{
    public interface IKeyword
    {
        HashSet<string> ListProcessor(HashSet<string> output, string id);
    }
}