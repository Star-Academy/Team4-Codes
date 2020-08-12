using System;
using System.IO;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class FileReader : IDBReader
    {

        public HashSet<Document> ReadAll(string path)
        {
            var output = new HashSet<Document>();
            foreach (string file in Directory.EnumerateFiles(path, "*.txt"))
            {
                string contents = File.ReadAllText(file).ToLower();
                output.Add(new Document{Id = Path.GetFileName(file), Content = contents});
            }
            return output;
        }
    }
}