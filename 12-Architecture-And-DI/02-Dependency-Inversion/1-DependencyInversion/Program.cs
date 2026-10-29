
class Program
{
    static void Main()
    {
        IMessageSender sender = new EmailSender();
        IMessageSender sender2 = new ConsoleSender();
        var processor = new OrderProcessor(sender);
        var processor2 = new OrderProcessor(sender2);

        processor.Process(40m);
        processor2.Process(20m);
    }
}
interface IMessageSender
{
    void Send(string text);
}
class OrderProcessor
{
    private readonly IMessageSender _sender;
    public OrderProcessor(IMessageSender _sender)
    {
        this._sender = _sender;
    }
    public void Process(decimal sum)
    {
        _sender.Send($"Order processed, total: {sum}");
    }
}
class EmailSender : IMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"email: {text}");
    }
}

class ConsoleSender : IMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"console: {text}");
    }
}

