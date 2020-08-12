using System;
using System.Collections.Generic;
using SearchLibrary;
using Xunit;
namespace Search.Test
{
    public class IKeywordTest
    {
        HashSet<string> result = new HashSet<string>() { "21", "72", "49", "160" };
        InvertedIndex Inverted;
        IKeywordList IKeyTest;

        [Fact]
        public void AndWordTest()
        {
            SetUp();
            IKeyTest = new NoSignKeyword();
            AddContent(IKeyTest);
            HashSet<string> output = IKeyTest.ListProcess(result, Inverted);
            Assert.Equal(new HashSet<string>() { "21" }, result);
        }
        [Fact]
        public void OrWordTest()
        {
            SetUp();
            IKeyTest = new PlusSignKeyword();
            AddContent(IKeyTest);
            HashSet<string> output = IKeyTest.ListProcess(result, Inverted);
            Assert.Equal(new HashSet<string>() { "21", "72", "49", "160" }, result);
        }
        [Fact]
        public void RemoveWordTest()
        {
            SetUp();
            IKeyTest = new MinusSignKeyword();
            AddContent(IKeyTest);
            HashSet<string> output = IKeyTest.ListProcess(result, Inverted);
            Assert.Equal(new HashSet<string>() { "160" }, result);
        }

        void AddContent(IKeywordList test)
        {
            test.Content.Add("rainy"); ///
            test.Content.Add("spider");
            test.Content.Add("day");
        }
        void SetUp()
        {
            var docs = new HashSet<Document>();
            var d1 = new Document { Id = "21", Content = "rainy day spider".ToLower() };
            var d2 = new Document { Id = "72", Content = "clOUdy day".ToLower() };
            var d3 = new Document { Id = "49", Content = "spIder man".ToLower() };
            docs.Add(d1);
            docs.Add(d2);
            docs.Add(d3);
            Inverted = new InvertedIndex();
            Inverted.FillMap(docs);
        }

    }
}