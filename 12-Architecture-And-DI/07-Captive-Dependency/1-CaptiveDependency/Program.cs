using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.Metrics;
using System.Reflection;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddScoped<Counter>();
        services.AddScoped<Report>();
        var provider = services.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true }); // new ServiceProviderOptions { ValidateScopes = true }

        using (var scope1 = provider.CreateScope())
        {
            var counter = scope1.ServiceProvider.GetRequiredService<Counter>();
            counter.Add();
            counter.Add();                                    // в этой группе Counter = 2

            var report = scope1.ServiceProvider.GetRequiredService<Report>();
            Console.WriteLine(report.Show());                 // 0
            /*System.InvalidOperationException: 'Cannot consume scoped service 'Counter' from singleton 'Report'.'*/
        }
    }
}
public class Report                                   // будет Singleton
{
    private readonly Counter _counter;                // а Counter будет Scoped
    public Report(Counter counter) { _counter = counter; }
    public int Show() => _counter.Value;
}
public class Counter
{
    public int Value = 0;
    public void Add() { Value++; }
}