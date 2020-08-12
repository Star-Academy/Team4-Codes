using SearchLibrary;
using System;
using System.Collections.Generic;
using Xunit;
namespace Search.Test
{
    public class InvertedIndexTest
    {
        [Fact]
        public void FillMapTest()
        {
            var docs = new HashSet<Document>();
            var d1 = new Document { Id = "file1.txt", Content = "rainy day".ToLower() };
            var d2 = new Document { Id = "file2.txt", Content = "clOUdy day".ToLower() };
            var d3 = new Document { Id = "file3.txt", Content = "spIder man".ToLower() };
            docs.Add(d1);
            docs.Add(d2);
            docs.Add(d3);
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.FillMap(docs);
            var expectedDictionary = new Dictionary<string, HashSet<string>>();
            expectedDictionary.Add("rainy", new HashSet<string>{"file1.txt"});
            expectedDictionary.Add("day", new HashSet<string>{"file1.txt", "file2.txt"});
            expectedDictionary.Add("cloudy", new HashSet<string>{"file2.txt"});
            expectedDictionary.Add("spider", new HashSet<string>{"file3.txt"});
            expectedDictionary.Add("man", new HashSet<string>{"file3.txt"});

            Assert.Equal(expectedDictionary, invertedIndex.Map);
        }
    }
}