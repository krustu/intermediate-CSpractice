
using System;
class Program
{
    static async Task Main()
    {


        await Task.Run(() => Increase());
        await Task.Run(() => Increase());

        Console.ReadLine();
    }
    static void Increase()
    {
        int counter = 0;
        for (int i = 0; i < 1000000; i++)
        {
            Interlocked.Increment(ref counter);

        }
        Console.WriteLine("The counter is " + counter);
    }
}

