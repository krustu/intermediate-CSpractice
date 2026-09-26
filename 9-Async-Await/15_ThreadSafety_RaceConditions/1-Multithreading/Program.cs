
using System;
class Program
{
    public static int counter = 0;
    static async Task Main()
    {


        var task1 = Task.Run(() => Increase());
        var task2 = Task.Run(() => Increase());


        await Task.WhenAll(task1, task2);

        Console.WriteLine($"Final counter: {counter}");
        //The counter is 1604546
        //The counter is 2000000
        Console.ReadLine();
    }
    static void Increase()
    {

        for (int i = 0; i < 1000000; i++)
        {
            Interlocked.Increment(ref counter);

        }
        Console.WriteLine("The counter is " + counter);
    }
}

