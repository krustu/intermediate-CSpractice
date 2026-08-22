using System;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
class Prgoram
{
    static void Main()
    {


        List<IShape> shapes = new List<IShape>
    {
    new Circle { Name = "Circle 1", Raduis = 5 },
    new Rectangle { Name = "Rectangle 1", Width = 10, Height = 4 },
    new Circle { Name = "Circle 2", Raduis = 3 },
    new Rectangle { Name = "Rectangle 2", Width = 7, Height = 6 },
    new Circle { Name = "Circle 3", Raduis = 8 },
    new Rectangle { Name = "Rectangle 3", Width = 12, Height = 5 },
    new Circle { Name = "Circle 4", Raduis = 2 },
    new Rectangle { Name = "Rectangle 4", Width = 4, Height = 9 }
    };
        Console.WriteLine("Lists: ");

        foreach (IShape shape in shapes)
        {
            ((ShapeBase)shape).Describe();
        }

        ShapeUtils.FindLargestByArea(shapes);
        ShapeUtils.TotalPerimeter(shapes);
        Console.ReadKey();
    }
}
public interface IShape
{
    string? Name { get; set; }
    double GetArea();
    double GetPerimeter();
}
public static class ShapeUtils
{

    public static List<IShape> FindLargestByArea(List<IShape> shapes)
    {

        var result = shapes[0];
        foreach (var a in shapes)
        {
            var resultArea = result.GetArea();
            var CurrentArea = a.GetArea();
            if (resultArea < CurrentArea)
            {
                result = a;
            }
        }
        List<IShape> resultList = new List<IShape>();
        resultList.Add(result);

        Console.WriteLine($"{result.Name} - Area: {result.GetArea()} Perimeter: {result.GetPerimeter()} ");
        Console.ReadKey();
        return resultList;
    }

    public static void TotalPerimeter(List<IShape> shapes)
    {
        double total = 0;
        Console.WriteLine("List of objects");
        foreach (var a in shapes)
        {
            total += a.GetArea();
            Console.WriteLine($"{a.Name} - Area: {a.GetArea()} Perimeter: {a.GetPerimeter()} ");
        }

        Console.WriteLine("Total sum of perimeter");
        Console.WriteLine(total);
        Console.ReadKey();
    }
}
public abstract class ShapeBase
{
    public string? Name { get; set; }
    public abstract double GetArea();
    public abstract double GetPerimeter();

    public virtual void Describe()
    {
        Console.WriteLine($"Result");
    }

}
public class Circle : ShapeBase, IShape
{
    public double Raduis { get; set; }

    public override double GetArea()
    {
        return Math.PI * Raduis * Raduis;

    }
    public override double GetPerimeter()
    {
        return 2 * Math.PI * Raduis;
    }
    public override void Describe()
    {
        //  base.Describe();
        Console.WriteLine($"{Name} - Area: {GetArea()} Perimeter: {GetPerimeter()} ");
    }

}
public class Rectangle : ShapeBase, IShape
{
    public double Width { get; set; }
    public int Height { get; set; }

    public override double GetArea()
    {
        return Width * Height;
    }
    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
    public override void Describe()
    {
        Console.WriteLine($"{Name} - Area: {GetArea()} Perimeter: {GetPerimeter()} ");
    }
}
