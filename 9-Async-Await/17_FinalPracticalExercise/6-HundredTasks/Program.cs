using System;
using System.ComponentModel;
class Program
{
    static async Task Main()
    {
        var tasks = new List<Task>();
        var num = new List<int>();
        for (int a = 0; a < 1000; a++) //swap 100 for 1000 to see exaclty difference
        {
            int value = a;
            tasks.Add(Task.Run(() =>
            {
                num.Add(value);
            }));
        }
        await Task.WhenAll(tasks);
        Console.WriteLine(num.Count); //960-990
    }
}