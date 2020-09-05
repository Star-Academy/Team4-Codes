using SearchEngineNestLib.Models;
using System.Collections.Generic;
using System.IO;

namespace SearchEngineNestLib
{
    public class DocReader : IReader
    {
        public List<Document> ReadAll(string path)
        {
            var output = new List<Document>();
            foreach (string file in Directory.EnumerateFiles(path))
            {
                string content = File.ReadAllText(file);
                output.Add(new Document{Id = Path.GetFileName(file), Content = content});
            }
            return output;
        }
    }
}