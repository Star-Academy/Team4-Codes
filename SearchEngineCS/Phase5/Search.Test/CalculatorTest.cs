using System;
using System.Collections.Generic;
using Xunit;
using SearchLibrary;
namespace Search.Test
{
    public class CalculatorTest
    {
        InvertedIndex Inverted;
        [Fact]
        public void CalculateTest()
        {
            SetUp();
            
        }
        public void SetUp()
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