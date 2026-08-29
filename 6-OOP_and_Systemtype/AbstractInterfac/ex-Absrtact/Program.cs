using System;
class Program
{
    static void Main()
    {
        List<Shape> Shapes = new List<Shape>
        {
            new Square(15.0),
            new Circle(15.0),
            new Triangle(15.0 , 20.0 ),
        };

        foreach (var shape in Shapes)
        {
            var result = shape.Area();
            Console.WriteLine($"{shape.Name} - {result}");
        }
        Console.ReadKey();
    }
}
public abstract class Shape
{
    public abstract string Name { get; }
    public abstract double Area();
}
public class Square : Shape
{
    public override string Name => "Square";
    public double Side { get; set; }
    public Square(double Side)
    {
        this.Side = Side;
    }
    public override double Area()
    {
        return Side * Side;
    }
}
public class Circle : Shape
{
    public override string Name => "Circle";
    public double Radius { get; set; }
    public Circle(double Radius)
    {
        this.Radius = Radius;
    }
    public override double Area()
    {
        return Math.PI * (Radius * Radius);
    }
}
public class Triangle : Shape
{
    public override string Name => "Triangle";
    public double Height { get; set; }
    public double Base { get; set; }
    public Triangle(double Height, double Base)
    {
        this.Height = Height;
        this.Base = Base;
    }
    public override double Area()
    {
        return Height * Base / 2;
    }
}