using System;
using library;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace driver_program
{
    class Program
    {
        private const string Scores_Path = "Scores.json";
        private const string Students_Path = "Students.json";
        private const int Best_To_Take_Count = 3;
        static void Main(string[] args)
        {
            var students = (new DataBaseReader(Students_Path, Scores_Path)).ReadStudentsData();
            foreach (Student student in students.OrderByDescending(s => s.Average).Take(Best_To_Take_Count)){
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Average);
            }
        }
    }
}
