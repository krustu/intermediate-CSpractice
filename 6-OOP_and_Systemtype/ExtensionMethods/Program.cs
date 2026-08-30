using System;
class Program
{
    static void Main()
    {
        string Fullname = "Rysbek Dokturbaev";
        var Result = Fullname.Truncut(10);


        Console.ReadKey();

    }
}
public static class StringBuilder
{
    public static string Truncut(this string amo, int max)
    {
        if (amo.Length <= max)
            return amo;
        return amo.Substring(0, max);
    }
}