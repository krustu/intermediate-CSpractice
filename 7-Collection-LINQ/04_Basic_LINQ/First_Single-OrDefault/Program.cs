using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 5, 1, 3, 1 };
        // 5


        int firstEven = numbers.FirstOrDefault(n => n % 2 == 0);
        Console.WriteLine(firstEven);
        // single when item is unique in otherwise it will throw an exception "first" cannot throw an exception if the item is not found, it will return the default value for the type (in this case, 0 for int)
        // first is the same as firstordefault but it will throw an exception if the item is not found

        try
        {
            int singleEven = numbers.Single(n => n % 2 == 0);
            Console.WriteLine(singleEven);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
