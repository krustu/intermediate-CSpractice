using System;
using System.Threading;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        Stopwatch time = Stopwatch.StartNew();
        Thread a1 = new Thread(() =>
        {
            Console.WriteLine($"Thread ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });

        Thread a2 = new Thread(() =>
        {
            Console.WriteLine($"Thread ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });

        Thread a3 = new Thread(() =>
        {
            Console.WriteLine($"Thread ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        ;
        Thread a4 = new Thread(() =>
        {
            Console.WriteLine($"Thread ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });

        Thread a5 = new Thread(() =>
        {
            Console.WriteLine($"Thread ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        a1.Start();
        a2.Start();
        a3.Start();
        a4.Start();
        a5.Start();

        time.Stop();
        Console.WriteLine($"Creation and Start : {time.ElapsedMilliseconds}");


        time.Restart();

        Task t1 = Task.Run(() =>
        {
            Console.WriteLine($"Task ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        Task t2 = Task.Run(() =>
        {
            Console.WriteLine($"Task ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        Task t3 = Task.Run(() =>
        {
            Console.WriteLine($"Task ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        Task t4 = Task.Run(() =>
        {
            Console.WriteLine($"Task ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });
        Task t5 = Task.Run(() =>
        {
            Console.WriteLine($"Task ID{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        });


        time.Stop();
        Console.WriteLine($"Task Creation and Start: {time.ElapsedMilliseconds}");
        Console.ReadKey();
    }
}