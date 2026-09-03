using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {



        var list = new List<int>();
        var hashSet = new HashSet<int>();

        for (int i = 0; i < 100000; i++)
        {
            list.Add(i);
            hashSet.Add(i);
        }


        var a = Stopwatch.StartNew();
        bool find1 = list.Contains(99999);
        a.Stop();
        Console.WriteLine($"List.Contains: {a.ElapsedTicks} ticks");

        var b = Stopwatch.StartNew();
        bool find2 = hashSet.Contains(99999);
        b.Stop();
        Console.WriteLine($"HashSet.Contains: {b.ElapsedTicks} ticks");



    }

}
