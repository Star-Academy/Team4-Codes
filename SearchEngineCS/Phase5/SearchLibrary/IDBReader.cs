using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public interface IDBReader
    {
         HashSet<Document> ReadAll(string path);
    }
}