using System.Collections.Generic;
using System;
namespace SearchApi.Models
{
    public class Input
    {
        public string Words{get; set;} = "hello";
        public HashSet<string> OrWords { get; } = new HashSet<string>();
        public HashSet<string> RemoveWords { get; } = new HashSet<string>();
        public HashSet<string> AndWords { get; } = new HashSet<string>();

        public void Process()
        {
            var keywords = Words.Split(' ');
            foreach (var keyword in keywords)
            {
                if (keyword.StartsWith("+"))
                {
                    OrWords.Add(keyword.Substring(1));
                }
                else if (keyword.StartsWith("-"))
                {
                     RemoveWords.Add(keyword.Substring(1));
                }
                else
                {
                     AndWords.Add(keyword);
                }
            }
        }
    }
}