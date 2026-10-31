using System;
using Microsoft.Extensions.DependencyInjection;
//Microsoft.Extensions.DependencyInjection
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        services.AddSingleton<IMessageSender, ConsoleSender>();
        services.AddSingleton<OrderService>();
        services.AddSingleton<App>();

        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<App>();
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
    private OrderService _service;
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

