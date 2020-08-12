using System;
namespace SearchLibrary
{
    public class ConsoleInput:IUserInput
    {
        public string ScanInput()
        {
            Console.WriteLine("\nEnter string to search");
            string input = Console.ReadLine();
            return input;
        }
    }
}