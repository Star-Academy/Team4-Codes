using SearchLibrary;
using System;
using Moq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Search.Test
{
    public class IDBReaderTest
    {
        [Fact]
        public void ReadAllTest()
        {
            var virtualDirectoryPath = CreateVirtualDirectory();
            var file1Path = CreateVirtualFile(virtualDirectoryPath, "file1.txt", "rainy day");
            // var file2Path = CreateVirtualFile(virtualDirectoryPath, "file2.txt", "clOUdy night");
            // var file3Path = CreateVirtualFile(virtualDirectoryPath, "file3.txt", "spIder man");

            var d1 = new Document { Id = "file1.txt", Content = "rainy day".ToLower() };
            // var d2 = new Document { Id = "file2.txt", Content = "clOUdy night".ToLower() };
            // var d3 = new Document { Id = "file3.txt", Content = "spIder man".ToLower() };
            var expectedSet = new HashSet<Document>();
            expectedSet.Add(d1);
            // expectedSet.Add(d2);
            // expectedSet.Add(d3);

            var reader = new FileReader();

            foreach (Document doc in expectedSet)
            {
                foreach (Document doc1 in reader.ReadAll(virtualDirectoryPath))
                {
                    Assert.Equal(doc, doc1);
                }
            }
        }

        public string CreateVirtualDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
        public string CreateVirtualFile(string directoryPath, string fileName, string content)
        {
            string filePath = directoryPath + "\\" + fileName;

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(content);
                }
            }

            return filePath;
        }
    }
}