using System;
using System.ComponentModel;
class Program
{
    static async Task Main()
    {
        var tasks = new List<Task>();
        var num = new List<int>();
        object locker = new object();
        for (int a = 0; a < 1000; a++)
        {
            int value = a;
            tasks.Add(Task.Run(() =>
            {
                lock (locker)
                {
                    num.Add(value);
                }

            }));
        }
        await Task.WhenAll(tasks);
        Console.WriteLine(num.Count);  // first way to solve


        var tasks2 = new List<Task<List<int>>>();
        for (int a = 0; a < 1000; a++)
        {
            int valuee = a;
            tasks2.Add(Task.Run(() =>
            {
                return new List<int> { valuee };
            }));

        }
        var result = await Task.WhenAll(tasks2);
        var num2 = result.SelectMany(x => x).ToList();
        Console.WriteLine(num2.Count);
    }
}