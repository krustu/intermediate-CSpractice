using System;
class Program
{
    static void Main()
    {

        //     Square a = new Square { Width = 20 , Height = 35 };
        // Console.WriteLine($" proporties - {a.Width}, {a.Height}");

        TestArea(new Rectangle());
        TestArea(new Square());



        Console.ReadKey();
    }
    static void TestArea(Rectangle r)
    {
        r.Width = 5;
        r.Height = 10;
        Console.WriteLine(r.Area()); // что ожидаем и что получим?
    }
}
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int Area() => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        get => base.Width;
        set
        {
            base.Width = value;
            base.Height = value;
        } // подгоняет и Height
    }
    public override int Height
    {
        get => base.Height;
        set
        {
            base.Height = value;
            base.Width = value;
        } // подгоняет и Width
    }
}
