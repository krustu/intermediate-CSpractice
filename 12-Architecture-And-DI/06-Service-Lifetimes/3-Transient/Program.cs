using Microsoft.Extensions.DependencyInjection;
using System;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddTransient<Counter>();                  // потом поменяй эту строку на AddSingleton
        var provider = services.BuildServiceProvider();

        var c1 = provider.GetRequiredService<Counter>();   // попросили первый раз
        var c2 = provider.GetRequiredService<Counter>();   // попросили второй раз

        c1.Add();
        c1.Add();                                          // увеличили только c1 на 2

        Console.WriteLine(c2.Value);
    }
}
public class Counter
{
    public int Value = 0;
    public void Add() { Value++; }
}
