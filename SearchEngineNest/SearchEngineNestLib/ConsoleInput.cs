using System;
namespace SearchEngineNestLib
{
    public class ConsoleInput:IUserInput
    {
        public string ScanInput()
        {
            Console.WriteLine(Consts.InputMessage);
            return Console.ReadLine();
        }
    }
}