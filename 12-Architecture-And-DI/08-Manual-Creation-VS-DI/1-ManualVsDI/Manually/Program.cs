using System;
class Program
{
    static void Main()
    {
        InMemoryOrderRepository memoryRepo =
            new InMemoryOrderRepository();
        ConsoleSender sender =
            new ConsoleSender();
        ConsoleLogger logger =
            new ConsoleLogger();

        OrderService service =
            new OrderService(memoryRepo, sender, logger);
        App app = new App(service);
        app.Run();

        //  Console.ReadKey();
        //  foreach(var a in memoryRepo.GetAll())
        //  {
        //      Console.WriteLine(a);
        //  }

    }
}
public interface ILogger
{
    void Log(string text);
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
    private readonly ILogger _logger;
    public OrderService(IOrderRepository order, IMessageSender sender, ILogger logger)
    {
        _order = order;
        _sender = sender;
        _logger = logger;
    }
    public void Place(string order)
    {
        _order.Save(order);
        _sender.Send(order);
        _logger.Log($"Order placed: {order}");
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
public class ConsoleLogger : ILogger
{
    public void Log(string text)
    {
        Console.WriteLine($"(Console) log _ {text} _");
    }
}

