
using System;
class Program
{
    static void Main()
    {
        Derived d = new Derived();
        Base b = d; // тот же объект, но переменная типа Base

        d.Greet();
        d.Hello();
        b.Greet();
        b.Hello();
    }
}
public class Base
{
    public virtual void Greet() => Console.WriteLine("Base greet");
    public void Hello() => Console.WriteLine("Base hello"); // без virtual
}

public class Derived : Base
{
    public override void Greet() => Console.WriteLine("Derived greet");
    public new void Hello() => Console.WriteLine("Derived hello");
}