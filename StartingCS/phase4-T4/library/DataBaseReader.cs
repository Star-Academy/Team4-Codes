using System;
using library;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace library
{
    public class DataBaseReader
    {
        private string StudentsPath { get; set; }
        private string ScoresPath { get; set; }
        public DataBaseReader(string studentsPath, string scoresPath)
        {
            StudentsPath = studentsPath;
            ScoresPath = scoresPath;
        }
        public List<Student> ReadStudentsData()
        {
            var scoresJson = File.ReadAllText(ScoresPath);
            var studentsJson = File.ReadAllText(StudentsPath);
            var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
            var scores = JsonSerializer.Deserialize<List<StudentScore>>(scoresJson);
            Dictionary<int, int> studentsIndices = new Dictionary<int, int>();
            studentsIndices = students.Select((n, i) => new { n, i }).ToDictionary(x => x.n.StudentNumber, x => x.i);
            foreach (StudentScore score in scores){
                students[studentsIndices[score.StudentNumber]].UpdateScores(score);
            }
            return students;
        }
    }
}