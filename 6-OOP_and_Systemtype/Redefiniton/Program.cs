using System;
class Program
{
    static void Main()
    {

        Point n1 = new Point(4, 5);

        Point n3 = n1;

        Point n2 = new Point(4, 5);


        Console.WriteLine(n1); // result "(3, 5)"

        Console.WriteLine(n1.Equals(n3/*n2*/)); // true or false

        Console.WriteLine(n1.Equals(n2)); // compare value instead of reference


        Console.ReadKey();
    }
}
public class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return ($"({Y},{X})");

    }
    public override bool Equals(object? obj)
    {
        if (obj is not Point other)
            return false;
        return X == other.X && Y == other.Y;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}