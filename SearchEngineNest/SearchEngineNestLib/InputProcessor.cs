using System.Collections.Generic;

namespace SearchEngineNestLib
{
    public class InputProcessor
    {
        private readonly IUserInput inputFromUser;
        public HashSet<string> OrWords { get; } = new HashSet<string>();
        public HashSet<string> RemoveWords { get; } = new HashSet<string>();
        public HashSet<string> AndWords { get; } = new HashSet<string>();


        public InputProcessor(IUserInput userInput)
        {
            this.inputFromUser = userInput;
        }
        public void Process()
        {
            var keywords = inputFromUser.ScanInput().Split(Consts.InputSplitterChar);
            foreach (string keyword in keywords)
            {
                if (keyword.StartsWith(Consts.OrWordsSign))
                {
                    OrWords.Add(keyword.Substring(1));
                }
                else if (keyword.StartsWith(Consts.RemoveWordsSign))
                {
                     RemoveWords.Add(keyword.Substring(1));
                }
                else
                {
                     AndWords.Add(keyword);
                }
            }
        }
    }
}