using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Ch04_RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter your age: ");
            string input = ReadLine();
            Regex ageChecker = new Regex(@"^\d$");
            if (ageChecker.IsMatch(input))
            {
                WriteLine("Thank you!");
            }
            else
            {
                WriteLine($"This is not a valid age: {input}");
            }
        }
    }
}