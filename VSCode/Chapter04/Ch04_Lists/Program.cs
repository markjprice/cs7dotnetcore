using System;
using static System.Console;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            WriteLine("Initial list");
            foreach (string city in cities)
            {
                WriteLine($"  {city}");
            }
            WriteLine($"The first city is {cities[0]}."); 
            WriteLine($"The last city is {cities[cities.Count - 1]}.");
            cities.Insert(0, "Sydney");
            WriteLine("After inserting Sydney at index 0");
            foreach (string city in cities)
            {
                WriteLine($"  {city}");
            }
            cities.RemoveAt(1);
            cities.Remove("Milan");
            WriteLine("After removing two cities");
            foreach (string city in cities)
            {
                WriteLine($"  {city}");
            }
        }
    }
}
