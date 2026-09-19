using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
class Program
{
    static async Task Main()
    {
        var sw1 = Stopwatch.StartNew();
        CpuBreakerWork();
        sw1.Stop();
        Console.WriteLine($"Sync: {sw1.ElapsedMilliseconds} ms");

        var sw2 = Stopwatch.StartNew();
        await CpuBreakerWorkAsync();
        sw2.Stop();
        Console.WriteLine($"Async: {sw2.ElapsedMilliseconds} ms");
    }
    static void CpuBreakerWork()
    {

        //  await Task.Delay(3000);

        for (int a = 1; a < 100_000_000_0; a++)
        {
            if (a == 100_000_000_0)
            {
                Console.WriteLine("Finish");
            }
        }
    }
    static async Task CpuBreakerWorkAsync()
    {
        await Task.Run(() => CpuBreakerWork());
    }
}

