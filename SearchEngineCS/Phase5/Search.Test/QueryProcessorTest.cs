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

            var query = new QueryProcessor(mUserInput.Object);
            var expectedOrWord = new HashSet<string>() {"world"};
            var expectedAndWord = new HashSet<string>() {"hello"};
            var expectedRemoveWord = new HashSet<string>() {"mamad"};

            query.Process();
            Assert.Equal(expectedAndWord, query.AndWords.Content);
            Assert.Equal(expectedOrWord, query.OrWords.Content);
            Assert.Equal(expectedRemoveWord, query.RemoveWords.Content);
        }
    }
}