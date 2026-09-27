using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        var timer = new Stopwatch();


        var a = GetNumberAsync();

        var b = GetNumberAsync();// anotherGetNumberAsync();

        var c = anotherGetNumberAsync();


        timer.Start();
        await Task.WhenAll(a, b, c);
        timer.Stop();
        Console.WriteLine($"time : {timer.ElapsedMilliseconds}mil.sec");
        // here we see answer 2-0 
        // beacuse Tread.Sleep intentionally get sleep
        // - and program falls into a dead sleep until program would finish
        // that is why this way can be dangurous 

    }
    static async Task<int> GetNumberAsync()
    {
        // await Task.Delay(1000);
        Thread.Sleep(1000);
        int a = 1;
        return a;
    }

    //here I add how can we use Thread.Sleep to get rid of it in another Streamand thats why program can normaly works
    static async Task<int> anotherGetNumberAsync()
    {
        return await Task.Run(() =>
        {
            Thread.Sleep(1000);
            int a = 1;
            return a;
        });

    }
}
