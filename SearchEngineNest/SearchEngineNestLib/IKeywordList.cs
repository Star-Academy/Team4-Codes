namespace SearchEngineNestLib
{
    public interface IKeywordList
    {
        HashSet<string> Content { get; }

        HashSet<string> ListProcess(HashSet<string> result, InvertedIndex tokens);
    }
}