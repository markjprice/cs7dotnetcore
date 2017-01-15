using System;
using static System.Console;
using static System.Convert;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = 10;
            double b = a; // an int can be stored in a double
            WriteLine(b);

            double c = 9.8;
            int d = (int)c; // compiler gives an error for this line
            WriteLine(d);

            long e = 10;
            int f = (int)e;
            WriteLine($"e is {e} and f is {f}");
            e = long.MaxValue;
            f = (int)e;
            WriteLine($"e is {e} and f is {f}");

            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");

            double i = 9.49;
            double j = 9.5;
            double k = 10.49;
            double l = 10.5;
            WriteLine($"i is {i}, ToInt(i) is {ToInt32(i)}");
            WriteLine($"j is {j}, ToInt(j) is {ToInt32(j)}");
            WriteLine($"i is {k}, ToInt(k) is {ToInt32(k)}");
            WriteLine($"j is {l}, ToInt(l) is {ToInt32(l)}");

            int number = 12;
            WriteLine(number.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());

        }
    }
}
