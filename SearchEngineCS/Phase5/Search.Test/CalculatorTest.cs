using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using SearchLibrary;
namespace Search.Test
{
    public class CalculatorTest
    {
        InvertedIndex Inverted;
        [Fact]
        public void CalculateTest()
        {
            var cal = new Calculator(Inverted);
            SetUp();
            
            var mUserInput = new Mock<IUserInput>();
            mUserInput.Setup(x => x.ScanInput()).Returns("day +spider -rainy");
            var qp = new QueryProcessor(mUserInput);
            qp.Process();
            cal.Calculate(qp);
            Assert.Equals(new HashSet(){"72", "49"}, cal.Result);
            
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