using System;
using System.Text;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();

        // string +=
        stopwatch.Start();

        string result = "";

        for (int i = 0; i < 10_000; i++)
        {
            result += i;
        }

        stopwatch.Stop();

        Console.WriteLine($"string += : {stopwatch.ElapsedMilliseconds} ms");


        // StringBuilder
        stopwatch.Restart();

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < 10_000; i++)
        {
            builder.Append(i);
        }

        stopwatch.Stop();

        Console.WriteLine($"StringBuilder: {stopwatch.ElapsedMilliseconds} ms");
    }
}