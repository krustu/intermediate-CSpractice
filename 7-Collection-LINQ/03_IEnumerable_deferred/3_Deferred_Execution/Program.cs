using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        var query = numbers.Where(n =>
        {
            Console.WriteLine($"Checking: {n}");
            return n % 2 == 0;
        }).ToList(); // Materialize the query
                     //filtring happens immediately because of ToList()

        /* Console.WriteLine("Second call through foreach:");
         foreach (var n in query)
         {
             Console.WriteLine($"Received: {n}");
         } */


        Console.WriteLine("First call to Count():");
        int count = query.Count();
        Console.WriteLine($"Result: {count}");

        Console.WriteLine("Second call through foreach:");
        foreach (var n in query)
        {
            Console.WriteLine($"Received: {n}");
        }
    }


}
