using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using SearchLibrary;
namespace Search.Test
{
    public class CalculatorTest
    {
        private InvertedIndex inverted;
        [Fact]
        public void CalculateTest()
        {
            inverted = SetUpInverted();
            var cal = new Calculator(inverted);

            var mUserInput = new Mock<IUserInput>();
            mUserInput.Setup(x => x.ScanInput()).Returns("day +spider -rainy");
            var qp = new QueryProcessor(mUserInput.Object);
            qp.Process();
            var result = cal.Calculate(qp);
            Assert.Equal(new HashSet<string>() { "72", "49" }, result);

        }
        public InvertedIndex SetUpInverted()
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