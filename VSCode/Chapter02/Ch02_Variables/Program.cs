using static System.Console;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var population = 66000000;
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // strings use double-quotes
            var letter = 'Z'; // chars use single-quotes
            var happy = true; // Booleans have value of true or false

            // declaring the size of the array
            string[] names = new string[4];
            // storing items at index positions
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";
            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]); // read the item at this index
            }

            Write($"The population of the UK is {population}. ");
            WriteLine($"The population of the UK is {population:N0}. ");
            WriteLine($"{weight}kg of {fruit} costs {price:C}.");

            Write("Type your name and press ENTER: ");
            string name = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello {name}, you look good for {age}.");

        }
    }
}
