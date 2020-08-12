using System;
using System.Collections.Generic;

namespace SearchLibrary
{
    public class InvertedIndex
    {
        Dictionary<string, HashSet<string>>  Map { get; set; }

        public InvertedIndex()
        {
            Map = new Dictionary<string, HashSet<string>>();

        }
    }
}