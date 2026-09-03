using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        List<string> Names = new List<string> { "Alice", "Bob", "Charlie", "Beckett Luna", "Langston Barber", "Della Becker", "Journey Horne", "Sergio Ware", "Sergio Ware", "Sergio Ware", "Elizabeth Rasmussen", "Nevaeh Odom", "Keily Knight", "Aspen Kirby", "Langston Barber", "Alia Guerra", "Beckett Luna", "Janelle Austin", "Ava Rich", "Justice Jackson", "Kylie Cardenas", "Delaney Dillon", "Rio Kerr", "Rowan Keller", "Elizabeth Rasmussen", "Langston Barber" };



        List<string> L = FindDuplicates(Names);


        Console.ReadKey();

    }
    static List<string> FindDuplicates(List<string> RandomNames)
    {
        HashSet<string> duplicates = new HashSet<string>();
        HashSet<string> uniques = new HashSet<string>();
        List<string> answer = new List<string>();
        foreach (var name in RandomNames)
        {
            if (!uniques.Add(name))
            {
                duplicates.Add(name);
            }


        }
        Console.WriteLine("Duplicates found: " + duplicates.Count);
        foreach (var name in duplicates)
        {
            Console.WriteLine(name);
        }
        Console.ReadKey();

        Console.WriteLine("Unique names found: " + uniques.Count);
        foreach (var name in uniques)
        {
            Console.WriteLine(name);
        }
        Console.ReadKey();
        return duplicates.ToList();
    }
}
