using System;
class Program
{
    static void Main()
    {
        List<string> names = new List<string> { "Alice", "Bob" };
        var query = names.Where(n => n.StartsWith("A"));

        names.Add("Anna"); // добавили ПОСЛЕ создания query

        Console.WriteLine("Первый перебор:");
        foreach (var n in query)
        {
            Console.WriteLine(n);
        }

        names.Remove("Alice"); // удалили ПОСЛЕ первого перебора

        Console.WriteLine("Второй перебор:");
        foreach (var n in query)
        {
            Console.WriteLine(n);
        }
    }
}