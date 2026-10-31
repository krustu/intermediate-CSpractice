using System;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        //services.AddSingleton<IMessageSender, ConsoleSender>();
        /*Unable to resolve service for type 'IMessageSender'
         * while attempting to activate 'OrderService*/
        //InvalidOperationException

        services.AddSingleton<IMessageSender, EmailSender>();
        //Email

        services.AddSingleton<OrderService>();
        services.AddSingleton<App>();

        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<App>();
        var app2 = provider.GetRequiredService<App>();

        Console.WriteLine(ReferenceEquals(app, app2));
        //true

        app.Run();



    }
}
public interface IOrderRepository
{
    void Save(string order);
}
public interface IMessageSender
{
    void Send(string text);
}
public class OrderService
{
    private readonly IOrderRepository _order;
    private readonly IMessageSender _sender;
    public OrderService(IOrderRepository order, IMessageSender sender)
    {
        _order = order;
        _sender = sender;
    }
    public void Place(string order)
    {
        _order.Save(order);
        _sender.Send(order);
    }
}
public class App
{
    private readonly OrderService _service;
    public App(OrderService service)
    {
        _service = service;
    }
    public void Run()
    {
        // 1 order
        _service.Place("Fanta");

        // 2 order
        _service.Place("cola");
    }
}
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<string> _orders = new();
    public void Save(string text)
    {
        _orders.Add(text);
    }
    public IReadOnlyList<string> GetAll()
    {
        return _orders;
    }
}
public class ConsoleSender : IMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"(Console) sent _ {text} _");

    }
}
public class EmailSender : IMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"(Email) sent _ {text} _");

    }
}

