using System;
using System.IO;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        // string path = "/Users/markjprice/Code/"; // macOS
        string path = @"C:\Code\"; // Windows

        FileStream file = null;
        StreamWriter writer = null;
        try
        {

            if (Directory.Exists(path))
            {
                file = File.OpenWrite(Path.Combine(path, "file.txt"));
                writer = new StreamWriter(file);
                writer.WriteLine("Hello C#!");
            }
            else
            {
                WriteLine($"{path} does not exist!");
            }
        }
        catch (Exception ex)
        {
            // if the path doesn't exist the exception will be caught
            WriteLine($"{ex.GetType()} says {ex.Message}");
        }
        finally
        {
            if (writer != null)
            {
                writer.Dispose();
                WriteLine("The writer's unmanaged resources have been disposed.");
            }
            if (file != null)
            {
                file.Dispose();
                WriteLine("The file's unmanaged resources have been disposed.");
            }
        }

        using (FileStream file2 = File.OpenWrite(
            Path.Combine(path, "file2.txt")))
        {
            using (StreamWriter writer2 = new StreamWriter(file2))
            {
                try
                {
                    writer2.WriteLine("Hello C#!");
                }
                catch (Exception ex)
                {
                    WriteLine($"{ex.GetType()} says {ex.Message}");
                }
            }
        }

    }
}