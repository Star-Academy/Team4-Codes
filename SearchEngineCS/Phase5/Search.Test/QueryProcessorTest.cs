using Moq;
using Xunit;
using SearchLibrary;
using System.Collections.Generic;
namespace Search.Test
{
    public class QueryProcessorTest
    {
        [Fact]
        public void inputMock()
        {
            var mUserInput = new Mock<UserInput>();
            mUserInput.Setup(x => x.ScanInput()).Returns("hello +world -mamad");

            QueryProcessor query = new QueryProcessor(mUserInput.Object);
            var ExpectedOrWord = new HashSet<string>();
            ExpectedOrWord.Add("world");
            var ExpectedAndWord = new HashSet<string>();
            ExpectedAndWord.Add("hello");
            var ExpectedRemoveWord = new HashSet<string>();
            ExpectedRemoveWord.Add("mamad");
            query.Process();
            Assert.Equal(ExpectedAndWord, query.AndWords);
            Assert.Equal(ExpectedOrWord, query.OrWords);
            Assert.Equal(ExpectedRemoveWord, query.RemoveWords);
        }
    }
}