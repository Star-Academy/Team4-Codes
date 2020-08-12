using System;
using System.Collections.Generic;
namespace SearchLibrary
{
    public class DataBaseReader
    {
        InvertedIndex Tokens { get; set; }
        IDBReader Freader {get; set;}
        string Path{get; set; }
        public DataBaseReader(IDBReader Freader , string Path, InvertedIndex Tokens)
        {
            this.Tokens = Tokens;
            this.Freader = Freader;
            this.Path = Path;
        }

        public void SendDataToInvertedIndex()
        {
            HashSet<Document> data = Freader.ReadAll(Path);
            Tokens.FillMap(data);
        }


    }
}