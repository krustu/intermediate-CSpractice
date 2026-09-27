using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    { //in this exampe all async functions do not do work in the same time 
        // each one wait previes to strat 
        // to make it work at the samea time we need to use WhenAll
        var timer2 = new Stopwatch();
        var timer = new Stopwatch();
        timer2.Start();
        timer.Start();

        int a = await GetNumberAsync();
        timer.Stop();
        Console.WriteLine($"time : {timer.ElapsedMilliseconds}mil.sec");

        timer.Restart();
        int b = await GetNumberAsync();
        timer.Stop();
        Console.WriteLine($"time : {timer.ElapsedMilliseconds}mil.sec");

        timer.Restart();
        int c = await GetNumberAsync();
        timer.Stop();
        Console.WriteLine($"time : {timer.ElapsedMilliseconds}mil.sec");
        timer2.Stop();
        Console.WriteLine($"time : {timer2.ElapsedMilliseconds}mil.sec");
    }
    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(1000);
        int a = 1;
        return a;
    }
}
