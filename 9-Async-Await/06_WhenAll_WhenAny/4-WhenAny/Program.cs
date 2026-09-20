using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {

        Stopwatch sw = Stopwatch.StartNew();

        Task<string> a = Func1();
        Task<string> b = Func2();
        Task<string> c = Func3();

        // Wait until the FIRST task finishes
        Task<string> winner = await Task.WhenAny(a, b, c);

        // Get the result of the task that finished first
        string result = await winner;

        sw.Stop();

        Console.WriteLine($"Winner: {result}");
        Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");


    }
    static async Task<string> Func1()
    {
        await Task.Delay(3000);
        return "First";
    }
    static async Task<string> Func2()
    {
        await Task.Delay(2500);
        return "Second";
    }
    static async Task<string> Func3()
    {
        await Task.Delay(2000);
        return "Third";
    }
}

