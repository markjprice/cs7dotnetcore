using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        //int x = 0;
        //while (x < 10)
        //{
        //    WriteLine(x);
        //    x++;
        //}

        int x = 0;
        do
        {
            WriteLine(x);
            x++;
        } while (x < 10);

        string[] names = { "Adam", "Barry", "Charlie" };
        foreach (string name in names)
        {
            WriteLine($"{name} has {name.Length} characters.");
        }

    }
}