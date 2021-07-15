using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static System.IO.Path;
using static System.Environment;
using static System.Console;
using System.Reflection;

namespace task_4
{
    class FileHandling<T>
    {
        public string Filename { get; set; }
        public FileHandling(string filename)
        {
            Filename = filename;
        }
        public List<T> GetData()
        {
            string jsonPath = Combine(CurrentDirectory, Filename);
            string data = File.ReadAllText(jsonPath);
            List<T> objects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(data);
            return objects;
        }
        
    }
}
