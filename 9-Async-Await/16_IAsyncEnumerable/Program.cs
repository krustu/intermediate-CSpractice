using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        var Timer = new Stopwatch();
        var StopBraek = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        Timer.Start();
        await foreach (int a in GetNumber(5).WithCancellation(StopBraek.Token))
        {
            Console.WriteLine($"task:{a} -> Completed");
        }
        Timer.Stop();
        Console.WriteLine($"time :{Timer.ElapsedMilliseconds}.milsec");


        List<Task<string>> collection = new()
        {
            Pages(1),
            Pages(2),
            Pages(3),
            Pages(4),
            Pages(5)

        };

        var result = await Task.WhenAll(collection);

        foreach (var a in result)
        {
            Console.WriteLine($"task:{a} -> Completed");
        }

    }
    static async Task<string> Pages(int i)
    {
        await Task.Delay(300);
        return $"page{i}";
    }


    public static async IAsyncEnumerable<int> GetNumber(int Maxcycle)
    {
        for (int a = 0; a < Maxcycle; a++)
        {
            await Task.Delay(300);
            Console.WriteLine($"Page: {a}");
            yield return a;
        }

    }
}
