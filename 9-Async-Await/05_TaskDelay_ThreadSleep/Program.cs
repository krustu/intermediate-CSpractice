using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        var time = Stopwatch.StartNew();
        List<Task> tasks = new List<Task>();

        for (int a = 1; a < 500; a++)
        {
            tasks.Add(Task.Run(() => BlockWithSleep()));
        }


        ThreadPool.GetAvailableThreads(out int freeAfterSleep, out _);
        Console.WriteLine($"free streams Sleep-version: {freeAfterSleep}");

        await Task.WhenAll(tasks);
        time.Stop();
        Console.WriteLine($"Sleep - {time.ElapsedMilliseconds}");
        time.Restart();
        List<Task> tasks2 = new List<Task>();
        for (int a = 1; a < 500; a++)
        {
            tasks2.Add(Task.Run(() => DelayAsync()));
        }


        ThreadPool.GetAvailableThreads(out int freeAfterDelay, out _);
        Console.WriteLine($"free streams Delay-version: {freeAfterDelay}");

        await Task.WhenAll(tasks2);
        time.Stop();
        Console.WriteLine($"Delay - {time.ElapsedMilliseconds}");
    }
    static async Task BlockWithSleep()
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Sleep - {Thread.CurrentThread.ManagedThreadId}");
    }
    static async Task DelayAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine($"Delay - {Thread.CurrentThread.ManagedThreadId}");
    }
}
