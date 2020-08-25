using System.Collections.Generic;

namespace SearchEngineNestLib
{
    public class InputProcessor
    {
        private readonly IUserInput inputFromUser;
        public List<string> OrWords { get; } = new List<string>();
        public List<string> RemoveWords { get; } = new List<string>();
        public List<string> AndWords { get; } = new List<string>();


        public InputProcessor(IUserInput userInput)
        {
            this.inputFromUser = userInput;
        }
        public void Process()
        {
            string[] keywords = inputFromUser.ScanInput().Split(' ');
            foreach (string keyword in keywords)
            {
                if (keyword.StartsWith("+"))
                {
                    OrWords.Add(keyword.Substring(1));
                }
                else if (keyword.StartsWith("-"))
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