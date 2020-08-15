using System;
using System.Collections.Generic;
using SearchLibrary;
using Xunit;
namespace Search.Test
{
    public class IKeywordTest
    {
        HashSet<string> result = new HashSet<string>() { "21", "72", "49", "160" };
        InvertedIndex inverted;

        public IKeywordTest()
        {
            inverted = SetUpInverted();
        }

        [Fact]
        public void AndWordTest()
        {
            var iKeyTest = new NoSignKeyword();
            AddContent(iKeyTest);
            var output = iKeyTest.ListProcess(result, inverted);
            Assert.Equal(new HashSet<string>() { "21" }, output);
        }
        [Fact]
        public void OrWordTest()
        {
            var iKeyTest = new PlusSignKeyword();
            AddContent(iKeyTest);
            var output = iKeyTest.ListProcess(result, inverted);
            Assert.Equal(new HashSet<string>() { "21", "72", "49", "160" }, output);
        }
        [Fact]
        public void RemoveWordTest()
        {
            var iKeyTest = new MinusSignKeyword();
            AddContent(iKeyTest);
            var output = iKeyTest.ListProcess(result, inverted);
            Assert.Equal(new HashSet<string>() { "160" }, output);
        }

        void AddContent(IKeywordList test)
        {
            test.Content.Add("rainy"); ///
            test.Content.Add("spider");
            test.Content.Add("day");
        }
        InvertedIndex SetUpInverted()
        {
            var docs = new HashSet<Document>();
            var d1 = new Document { Id = "21", Content = "rainy day spider".ToLower() };
            var d2 = new Document { Id = "72", Content = "clOUdy day".ToLower() };
            var d3 = new Document { Id = "49", Content = "spIder man".ToLower() };
            docs.Add(d1);
            docs.Add(d2);
            docs.Add(d3);
            inverted = new InvertedIndex();
            inverted.FillMap(docs);
            return inverted;
        }

    }
}