using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        var timer = new Stopwatch();


        var a = GetNumberAsync();
        // added another funcrion not a same one
        var b = anotherGetNumberAsync();

        var c = GetNumberAsync();


        timer.Start();
        await Task.WhenAll(a, b, c);
        timer.Stop();
        Console.WriteLine($"time : {timer.ElapsedMilliseconds}mil.sec");
        // As I said earlier here we are using WhenAll.
        // and If you havent noticed I remove each await from function and add only one before await.
        // It is need to orginize all three functions to wait until all functionc will completed
    }
    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(1000);
        int a = 1;
        return a;
    }
    // here I add another function to make some experiment and check how times is work
    static async Task<int> anotherGetNumberAsync()
    {
        await Task.Delay(1500);
        int a = 1;
        return a;
    }
}
