using Microsoft.Extensions.DependencyInjection;
using System;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IdService>();              // меняем только эту строку: AddScoped / AddTransient
        var provider = services.BuildServiceProvider();

        using (var scope1 = provider.CreateScope())      // первая область
        {
            var a = scope1.ServiceProvider.GetRequiredService<IdService>();
            var b = scope1.ServiceProvider.GetRequiredService<IdService>();
            Console.WriteLine($"scope1: {a.Id == b.Id}");
        }
        using (var scope2 = provider.CreateScope())      // вторая область
        {
            var c = scope2.ServiceProvider.GetRequiredService<IdService>();
            Console.WriteLine($"scope2 vs scope1: {c.Id}");
        }
    }
}
public class IdService
{
    public Guid Id { get; } = Guid.NewGuid();    // новый уникальный номер при создании объекта
}
