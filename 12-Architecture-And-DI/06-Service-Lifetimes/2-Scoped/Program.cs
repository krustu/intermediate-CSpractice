using Microsoft.Extensions.DependencyInjection;
using System;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddScoped<Counter>();
        var provider = services.BuildServiceProvider();

        using (var scope1 = provider.CreateScope())                              // первая группа
        {
            var a = scope1.ServiceProvider.GetRequiredService<Counter>();
            var b = scope1.ServiceProvider.GetRequiredService<Counter>();
            a.Add();
            a.Add();
            Console.WriteLine(b.Value);                                          // что выведет?
        }

        using (var scope2 = provider.CreateScope())                              // вторая группа
        {
            var c = scope2.ServiceProvider.GetRequiredService<Counter>();
            Console.WriteLine(c.Value);                                          // а здесь?
        }
    }
}
public class Counter
{
    public int Value = 0;
    public void Add() { Value++; }
}
