using System;
using Packt.CS7;
using static System.Console;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}");
            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");
            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");
            p1.Children.Add(new Person());
            p1.Children.Add(new Person());
            WriteLine($"{p1.Name} has {p1.Children.Count} children.");

            var p2 = new Person { Name = "Alice Jones", DateOfBirth = new DateTime(1998, 3, 17) };
            WriteLine($"{p2.Name} was born on {p2.DateOfBirth:d MMM yy}");

            BankAccount.InterestRate = 0.012M;
            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 2400;
            WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");
            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

            WriteLine($"{p1.Name} is a {Person.Species}");
            WriteLine($"{p1.Name} was born on {p1.HomePlanet}");

            var p3 = new Person();
            WriteLine($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}");

            var p4 = new Person("Aziz");
            WriteLine($"{p4.Name} was instantiated at {p4.Instantiated:hh:mm:ss} on {p4.Instantiated:dddd, d MMMM yyyy}");

            p1.WriteToConsole();
            WriteLine(p1.GetOrigin());

            WriteLine(p1.SayHello());
            WriteLine(p1.SayHello("Emily"));

            Tuple<string, int> fruit4 = p1.GetFruit4();
            WriteLine($"There are {fruit4.Item2} {fruit4.Item1}.");

            // the new C# 7 syntax and new System.ValueTuple type
            // (string, int) fruit7 = p1.GetFruit7();
            // WriteLine($"There are {fruit7.Item2} {fruit7.Item1}.");

            //(string Name, int Number) fruitNamed7 = p1.GetNamedFruit7();
            //WriteLine($"Are there {fruit7.Number} {fruit7.Name}?");
            

            p1.OptionalParameters();
            p1.OptionalParameters("Jump!", 98.5);
            p1.OptionalParameters(number: 52.7, command: "Hide!");
            p1.OptionalParameters("Poke!", active: false);

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            p1.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            // simplified C# 7 syntax for out parameters
            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
            // p1.PassingParameters(d, ref e, out int f);
            // WriteLine($"After: d = {d}, e = {e}, f = {f}");

            var max = new Person { Name = "Max", DateOfBirth = new DateTime(1972, 1, 27) };
            WriteLine(max.Origin);
            WriteLine(max.Greeting);
            WriteLine(max.Age);

            max.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"Max's favorite ice-cream flavor is {max.FavoriteIceCream}.");
            max.FavoritePrimaryColor = "Red";
            WriteLine($"Max's favorite primary color is {max.FavoritePrimaryColor}.");

            max.Children.Add(new Person { Name = "Charlie" });
            max.Children.Add(new Person { Name = "Ella" });
            WriteLine($"Max's first child is {max.Children[0].Name}");
            WriteLine($"Max's second child is {max.Children[1].Name}");
            WriteLine($"Max's first child is {max[0].Name}");
            WriteLine($"Max's second child is {max[1].Name}");
        }
    }
}
