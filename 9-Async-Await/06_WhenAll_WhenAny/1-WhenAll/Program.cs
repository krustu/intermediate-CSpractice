using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        var Time = Stopwatch.StartNew();
        Task<int> a = SquareAsync(5);
        Task<int> b = SquareAsync(5);
        Task<int> c = SquareAsync(5);
        Task<int> d = SquareAsync(5);
        Task<int> e = SquareAsync(5);
        int[] tasks = await Task.WhenAll(a, b, c, d, e);
        // WhenAll made a Array
        Time.Stop();

        Console.WriteLine($"Time - {Time.ElapsedMilliseconds} millisecond");
        Console.WriteLine(a.Result);

    }
    static async Task<int> SquareAsync(int n)
    {
        await Task.Delay(1000);
        return n *= 2;

    }
}
