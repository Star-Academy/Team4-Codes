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
                string contents = File.ReadAllText(file).ToLower();
                output.Add(new Document{ID = Path.GetFileName(file), Content = contents});
            }
            return output;
        }
    }
}