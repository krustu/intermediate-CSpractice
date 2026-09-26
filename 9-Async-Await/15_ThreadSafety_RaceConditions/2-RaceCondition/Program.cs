using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
class Program
{
    static async Task Main()
    {
        var test1 = new List<Task>();
        var test2 = new List<Task>();
        var test3 = new List<Task>();
        var test4 = new List<Task>();
        int counter = 0;

        // cycle of 100 
        for (int a = 0; a < 100; a++)
        {
            test1.Add(Task.Run(() => counter++));
        }
        await Task.WhenAll(test1);

        Console.WriteLine($"(100)count - {counter}"); //answer : 98 - 100 more often 100;

        counter = 0;

        //cycle of 1000+
        for (int a = 0; a < 10000; a++)
        {
            test2.Add(Task.Run(() => counter++));
        }
        await Task.WhenAll(test2);
        Console.WriteLine($"(1000)count - {counter}"); // 9840 - 9990 but never 10000;

        counter = 0;

        //Fixed method / three way  to write object

        // object Locker = new object();
        object Locker = new();
        // var Locker = new object();
        var Timer = new Stopwatch();
        Timer.Start();
        for (int a = 0; a < 1000000; a++)
        {
            test3.Add(Task.Run(() =>
            {
                lock (Locker)
                {
                    counter++;
                }
            }));
        }
        await Task.WhenAll(test3);

        Timer.Stop();
        Console.WriteLine($"(Locker method )count - {counter}");
        Console.WriteLine($"Time - {Timer.ElapsedMilliseconds}.milsec");
        counter = 0;
        Timer.Restart();

        for (int a = 0; a < 1000000; a++)
        {
            test4.Add(Task.Run(() =>
            {
                Interlocked.Increment(ref counter);
            }));
        }
        await Task.WhenAll(test4);

        Timer.Stop();
        Console.WriteLine($"(Interlocked.Increment(ref x) )count - {counter}");
        Console.WriteLine($"Time - {Timer.ElapsedMilliseconds}.milsec");
    }
}