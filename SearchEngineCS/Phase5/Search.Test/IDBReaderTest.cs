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

            var d1 = new Document { Id = "file1.txt", Content = "rainy day".ToLower() };

            var expectedSet = new HashSet<Document>();
            expectedSet.Add(d1);   

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