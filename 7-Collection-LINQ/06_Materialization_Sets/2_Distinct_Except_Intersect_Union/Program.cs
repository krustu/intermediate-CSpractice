using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        List<string> group1 = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Alice", "Aloopa" };
        List<string> group2 = new List<string> { "Charlie", "Diana", "Eve", "Frank" };

        var result = group1.Distinct().ToList();
        var result2 = group1.Except(group2).ToList();
        var result3 = group1.Intersect(group2).ToList();
        var result4 = group1.Union(group2).ToList();

        Console.WriteLine("Distinct names in group1:");
        foreach (var name in result)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nNames in group1 that are not in group2:");
        foreach (var name in result2)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nNames common to both group1 and group2:");
        foreach (var name in result3)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("\nFull list of Students:");
        foreach (var name in result4)
        {
            Console.WriteLine(name);
        }
    }
}


