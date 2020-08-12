using System.Collections.Generic;
using System;
namespace SearchLibrary
{
    public abstract class IKeywordList
    {
        public HashSet<string> Content { get; set; }
        protected IKeywordList(){
            Content = new HashSet<string>();
        }
        public abstract HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens);
    }
}