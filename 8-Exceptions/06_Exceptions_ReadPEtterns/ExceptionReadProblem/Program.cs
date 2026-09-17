using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        Order a = new Order();
        a.PrintFirstItem();
        Console.ReadKey();
        StackTrace ResultMistake = new StackTrace();
        Console.WriteLine(ResultMistake);
    }
}
public class Order
{
    List<string> Item = new();
    public void PrintFirstItem()
    {
        try
        {
            if (Item != null && Item.Count > 0)
                Console.WriteLine(Item[0]);

            else
            {
                //  string item = Item?[0] ?? "Nothing";
                Console.WriteLine("Nothing");

            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw;

        }
    }
}
