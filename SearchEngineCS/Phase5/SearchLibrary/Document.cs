using System;
namespace SearchLibrary
{
    public class Document
    {
        public string Id { get; set; }
        public string Content { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Document document &&
                   Id == document.Id &&
                   Content == document.Content;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Content);
        }
    }
}