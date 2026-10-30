using System;
class Program
{
    static void Main()
    {
        try
        {

            var service = new ReportService(new RandomDataSource(), new ConsoleSender());
            service.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
interface IDataSource
{
    int[] GetNumbers();
}
interface IMessageSender
{
    void Send(string text);
}
class ReportService
{
    private readonly IDataSource _source;
    private readonly IMessageSender _sender;
    public ReportService(IDataSource source, IMessageSender sender)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(sender);
        _sender = sender;
        _source = source;
    }
    public void Run()
    {
        int[] arraynum = _source.GetNumbers();
        int answer = 0;
        foreach (var a in arraynum)
        {
            answer += a;
        }


        _sender.Send(answer.ToString());

    }
}
class ConsoleSender : IMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"We get :{text} ");
    }
}
class FixedDataSource : IDataSource
{
    public int[] GetNumbers()
    {
        return new int[] { 1, 2, 3 };
    }
}
class RandomDataSource : IDataSource
{
    public int[] GetNumbers()
    {
        Random random = new Random();
        return Enumerable.Range(0, 3).Select(_ => random.Next(1, 101)).ToArray();
    }
}

