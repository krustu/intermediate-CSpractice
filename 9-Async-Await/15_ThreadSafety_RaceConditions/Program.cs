using System;
using System.Collections.Concurrent;
class Program
{
    static async Task Main()
    {
        //   var numbers = new ConcurrentBag<int>();
        var numbers = new List<int>();
        //second method with Lock
        var resulTasks = new List<Task>();
        var lockobject = new object();

        for (int a = 0; a < 1000; a++)
        {

            int captured = a;

            resulTasks.Add(Task.Run(() =>
            {
                lock (lockobject)
                {
                    numbers.Add(captured);
                }


            }));
        }
        await Task.WhenAll(resulTasks);
        Console.WriteLine(resulTasks.Count);
        Console.WriteLine(numbers.Count);
    }

}//ConcurrentBag/ConcurrentDictionary Collections for async functions