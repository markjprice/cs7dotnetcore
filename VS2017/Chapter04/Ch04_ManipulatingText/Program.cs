using System;
using static System.Console;

namespace Ch04_ManipulatingText
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long.");
            WriteLine($"First char is {city[0]} and third is {city[2]}.");

            string cities = "Paris,Berlin,Madrid,New York";
            string[] citiesArray = cities.Split(',');
            foreach (string item in citiesArray)
            {
                WriteLine(item);
            }

            string fullname = "Alan Jones";
            int indexOfTheSpace = fullname.IndexOf(' ');
            string firstname = fullname.Substring(0, indexOfTheSpace);
            string lastname = fullname.Substring(indexOfTheSpace + 1);
            WriteLine($"{lastname}, {firstname}");

            string company = "Microsoft";
            bool startsWithM = company.StartsWith("M");
            bool containsN = company.Contains("N");
            WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");

            string recombined = string.Join(" => ", citiesArray);
            WriteLine(recombined);

        }
    }
}