using System.Collections.Generic;
using System;
namespace SearchLibrary
{
    public class NoSignKeyword : IKeyword
    {
        public HashSet<string> ListProcessor(HashSet<string> output, string id)
        {
            throw new NotImplementedException();
        }
    }
}