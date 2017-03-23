using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using Newtonsoft.Json;

namespace Ch10_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object graph
            var people = new List<Person>
            {
              new Person(30000M) { FirstName = "Alice", LastName = "Smith",
                DateOfBirth = new DateTime(1974, 3, 14) },
              new Person(40000M) { FirstName = "Bob", LastName = "Jones",
                DateOfBirth = new DateTime(1969, 11, 23) },
              new Person(20000M) { FirstName = "Charlie", LastName = "Rose",
                DateOfBirth = new DateTime(1964, 5, 4),
                Children = new HashSet<Person>
                { new Person(0M) { FirstName = "Sally", LastName = "Rose",
                DateOfBirth = new DateTime(1990, 7, 12) } } }
            };

            // create a file to write to
            // string xmlFilepath = @"/Users/markjprice/Code/Ch10_People.xml";
            string xmlFilepath = @"C:\Code\Ch10_People.xml"; // Windows
            FileStream xmlStream = File.Create(xmlFilepath);

            // create an object that will format as List of Persons as XML
            var xs = new XmlSerializer(typeof(List<Person>));

            // serialize the object graph to the stream
            xs.Serialize(xmlStream, people);

            // you must close the stream to release the file lock
            xmlStream.Dispose();

            WriteLine($"Written {new FileInfo(xmlFilepath).Length} bytes of XML to {xmlFilepath}");
            WriteLine();

            // Display the serialized object graph
            WriteLine(File.ReadAllText(xmlFilepath));

            FileStream xmlLoad = File.Open(xmlFilepath, FileMode.Open);
            // deserialize and cast the object graph into a List of Person
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
            foreach (var item in loadedPeople)
            {
                WriteLine($"{item.LastName} has {item.Children.Count} children.");
            }
            xmlLoad.Dispose();

            // create a file to write to
            // string jsonFilepath = @"/Users/markjprice/Code/Ch10_People.json";
            string jsonFilepath = @"C:\Code\Ch10_People.json"; // Windows
            StreamWriter jsonStream = File.CreateText(jsonFilepath);

            // create an object that will format as JSON
            var jss = new JsonSerializer();

            // serialize the object graph into a string
            jss.Serialize(jsonStream, people);

            // you must dispose the stream to release the file lock
            jsonStream.Dispose();

            WriteLine();
            WriteLine($"Written {new FileInfo(jsonFilepath).Length} bytes of JSON to: {jsonFilepath}");

            // Display the serialized object graph
            WriteLine(File.ReadAllText(jsonFilepath));

        }
    }
}