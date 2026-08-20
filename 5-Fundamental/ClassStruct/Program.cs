using System;
class Program
{
    static void Main()
    {

        var (ok, iferror) = CheckAge(17);
        Console.WriteLine(iferror);
            Console.WriteLine(ok);
        Console.ReadKey();
    }
    static (bool ok , string iferror) CheckAge(int age)
    {
        if (age < 18)
        {
            return (false, "you must be older than 18");
        }
        return (true, "");
    }
    
}


/*static void Main()
    {
       

    var p1 = new Point(1, 2);
    var p2 = p1 with { Y = 99 };

    Console.WriteLine(p1.X + " " + p1.Y);
    Console.WriteLine(p2.X + " " + p2.Y);
    Console.WriteLine(ReferenceEquals(p1, p2));
        
    }*/
/*public record Point(int X, int Y);*/