using static System.Console;
using System;

class Program
{
    static void Main(string[] args)
    {
        ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
        BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[1], true);
        WindowWidth = int.Parse(args[2]);
        WindowHeight = int.Parse(args[3]);

        WriteLine($"There are {args.Length} arguments.");
        foreach (string arg in args)
        {
            WriteLine(arg);
        }
    }
}