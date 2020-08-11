using System;
namespace SearchLibrary
{
    public class UserInput
    {
        public virtual string ScanInput()
        {
            Console.WriteLine("Enter string to search");
            string input = Console.ReadLine();
            return input;
        }
    }
}