namespace SearchEngineNestLib
{
    public class Consts
    {
        static public string ClientUri = "http://localhost:9200";
        static public string InputMessage = "\nEnter string to search";
        static public string StandardTokenizer = "standard";
        static public string LowercaseFilter = "lowercase";
        static public char InputSplitterChar = ' ';
        static public string OrWordsSign = "+";
        static public string RemoveWordsSign = "-";
        static public string ResultMessage = "{0} Results Found: ";
        static public string ResultSplitter = " ";
        static public string Error400 = "Bad Request";
        static public string Error404 = "Index not found";
        static public string Error403 = "Index is read only";
        static public string Error409 = "Conflict in indices";
    }
}