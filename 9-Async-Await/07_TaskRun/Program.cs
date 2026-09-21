using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        Console.WriteLine($"Main cuurent {Environment.CurrentManagedThreadId}");
        var result = await LegacySlowMethod();
        var Resu2 = await BugBadMethod();
        Console.WriteLine(result);
        Console.WriteLine(Resu2);

    }
    static Task<string> LegacySlowMethod()
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Worker thread: {Environment.CurrentManagedThreadId}");
            Thread.Sleep(2000);
            //some process of working... in another stream
            return "Ready";
        });


    }
    static async Task<string> BugBadMethod()
    {
        return await Task.Run(async () =>
        {
            await Task.Delay(1000);
            return "Ready";
        });
    }
}
