using System;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        int age = int.Parse("27");
        DateTime birthday = DateTime.Parse("4 July 1980");
        WriteLine($"I was born {age} years ago.");
        WriteLine($"My birthday is {birthday}.");
        WriteLine($"My birthday is {birthday:D}.");

        Write("How many eggs are there? ");
        int count;
        string input = Console.ReadLine();
        if (int.TryParse(input, out count))
        {
            WriteLine($"There are {count} eggs.");
        }
        else
        {
            WriteLine("I could not parse the input.");
        }

    }
}