using System.Collections.Generic;
using System;
namespace SearchLibrary
{
    public interface Keyword
    {
        HashSet<string> ListProcessor(HashSet<string> output, string id);

    }
}