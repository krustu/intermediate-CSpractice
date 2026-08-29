using System;
class Program
{
    static void Main()
    {
        List<IShape> Shapes = new List<IShape>
        {
            new Square(15.0),
            new Circle(15.0),
            new Triangle(15.0 , 20.0 ),
        };

        foreach (IShape shape in Shapes)
        {
            var result = shape.Area();
            Console.WriteLine(result);
        }
        Console.ReadKey();
    }
}
public interface IShape
{
    double Area();
}
public class Square : IShape
{
    public double Side { get; set; }
    public Square(double Side)
    {
        this.Side = Side;
    }
    public double Area()
    {
        return Side * Side;
    }
}
public class Circle : IShape
{
    public double Radius { get; set; }
    public Circle(double Radius)
    {
        this.Radius = Radius;
    }
    public double Area()
    {
        return Math.PI * (Radius * Radius);
    }
}
public class Triangle : IShape
{
    public double Height { get; set; }
    public double Base { get; set; }
    public Triangle(double Height, double Base)
    {
        this.Height = Height;
        this.Base = Base;
    }
    public double Area()
    {
        return Height * Base / 2;
    }
}
