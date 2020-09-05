using System.Collections.Generic;
using SearchEngineNestLib;

namespace SearchEngineNestLib.Models
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
            int hashCode = 1058685026;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}