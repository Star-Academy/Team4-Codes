using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nest;
using ElasticLib.Models;

namespace ElasticLib
{
    public class PeopleReader
    {
        public List<Person> Read(string path){
            var json = File.ReadAllText(path);
            var people = JsonSerializer.Deserialize<List<Person>>(json);
            return people;
        }
    }
}