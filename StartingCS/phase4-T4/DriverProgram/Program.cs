using System;
using library;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DriverProgram
{
    class Program
    {
        private const string ScoresPath = "Scores.json";
        private const string StudentsPath = "Students.json";
        private const int BestToTakeCount = 3;
        static void Main(string[] args)
        {
            var reader = new DataBaseReader(StudentsPath, ScoresPath);
            var bestStudents = (reader).ReadStudentsData()
                .OrderByDescending(s => s.Average)
                .Take(BestToTakeCount);
            foreach (Student student in bestStudents){
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Average);
            }
        }
    }
}
