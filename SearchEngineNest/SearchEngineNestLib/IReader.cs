using SearchEngineNestLib.Models;
using System.Collections.Generic;

namespace SearchEngineNestLib
{
    public interface IReader
    {
        List<Document> ReadAll(string path);
    }
}