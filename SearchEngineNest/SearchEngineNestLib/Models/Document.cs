using System.Collections.Generic;
using SearchEngineNestLib;

namespace SearchEngineNestLib.Models
{
    public class Document
    {
        public string ID { get; set; }
        public string Content { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Document document &&
                   ID == document.ID &&
                   Content == document.Content;
        }

        public override int GetHashCode()
        {
            int hashCode = 1058685026;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            return hashCode;
        }
    }
}