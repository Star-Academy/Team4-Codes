using System;
namespace SearchLibrary
{
    public class Document
    {
        public string Id { get; set; }
        public string Content { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Document doc = (Document)obj;
            return this.Id.Equals(doc.Id) && this.Content.Equals(doc.Content);
        }

    
    }
}