using System;
namespace SearchEngineNestLib
{
    public class ConsoleInput:IUserInput
    {
        public string ScanInput()
        {
            Console.WriteLine("\nEnter string to search");
            return Console.ReadLine();
        }
    }
}