using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {

        CheckWithIf(-1);
        CheckWithException(-1);

        var a = Stopwatch.StartNew();
        for (int i = -10000; i < 1; i++)
        {
            CheckWithIf(i);
        }
        a.Stop();
        Console.WriteLine($"CheckWithIf - {a.ElapsedTicks}");

        a.Restart();
        for (int i = -10000; i < 1; i++)
        {
            CheckWithException(i);
        }
        a.Stop();
        Console.WriteLine($"CheckWithException - {a.ElapsedTicks}");
    }
    public static bool CheckWithIf(int n)
    {
        if (n < 0)
        {
            return false;
        }
        return true;
    }
    public static bool CheckWithException(int n)
    {
        try
        {
            if (n < 0)
                throw new ArgumentException();
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
