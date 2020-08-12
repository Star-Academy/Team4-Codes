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
            var mUserInput = new Mock<IUserInput>();
            mUserInput.Setup(x => x.ScanInput()).Returns("hello +world -mamad");
            var result = new HashSet<string>();

            QueryProcessor query = new QueryProcessor(mUserInput.Object);
            var ExpectedOrWord = new HashSet<string>();
            ExpectedOrWord.Add("world");
            var ExpectedAndWord = new HashSet<string>();
            ExpectedAndWord.Add("hello");
            var ExpectedRemoveWord = new HashSet<string>();
            ExpectedRemoveWord.Add("mamad");
            query.Process();
            Assert.Equal(ExpectedAndWord, query.AndWords.Content);
            Assert.Equal(ExpectedOrWord, query.OrWords.Content);
            Assert.Equal(ExpectedRemoveWord, query.RemoveWords.Content);
        }
    }
}