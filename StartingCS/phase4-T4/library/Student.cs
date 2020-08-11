using System;
using System.Collections.Generic;

namespace library
{
    public class Student
    {
        public int StudentNumber {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        List<StudentScore> Scores {get; set;}
        public double Average {get; set;}
        private int ScoresCount {get; set;}
        private double ScoresSum {get; set;}
        Student(){
            ScoresCount = 0;
            ScoresSum = 0;
            Scores = new List<StudentScore>();
        }
        public void UpdateScores(StudentScore sc){
            this.Scores.Add(sc);
            this.ScoresSum += sc.Score;
            this.ScoresCount ++;
            this.Average = this.ScoresSum/this.ScoresCount;
        }
        
    }
}
