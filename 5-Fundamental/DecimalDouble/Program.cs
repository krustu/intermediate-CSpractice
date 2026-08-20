using System;
class Program
{
    static void Main(string[] args)
    {
        double a = 10;
        double b = 0.1;
        double result = a * b * b * b * b * b ;


        decimal aa = 10m;
        decimal bb = .1m;
        decimal result2 = aa * bb * bb * bb * bb * bb ;


        Console.WriteLine("with using double ");
        Console.WriteLine(result);
        Console.ReadKey();
        Console.WriteLine("with using decimal");
        Console.WriteLine(result2);
        // double is using boinary colculation and it would be difficilt for programm to count 19.999 or smt else
        // decimal was create excalty for financal colcutaton
    }
}
