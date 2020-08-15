using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchLibrary
{
    public class InvertedIndex
    {
        public Dictionary<string, HashSet<string>> Map { get; } = new Dictionary<string, HashSet<string>>();

        public void FillMap(HashSet<Document> data)
        {
            foreach (Document doc in data)
            {
                ProcessDoc(doc);
            }
        }

        public void ProcessDoc(Document doc)
        {
            string[] wordsInDoc;
            List<string> wordsInDocList;
            wordsInDoc = doc.Content.Split(" ");
            wordsInDocList = wordsInDoc.ToList();
            wordsInDocList = wordsInDocList.ConvertAll(d => d.ToLower());
            foreach (string word in wordsInDoc)
            {
                if (Map.ContainsKey(word))
                {
                    Map[word].Add(doc.Id);
                }
                else
                {
                    Map.Add(word, new HashSet<string> { doc.Id });
                }
            }
        }
    }
}