using System;
using System.ComponentModel;
class Program
{
    static void Main()
    {
        List<INotifier> notifiers = new List<INotifier>
        {
            new EmailNotifier(),
            new SmsNotifier(),
            new PushNotifier()
        };

        NotifyAll(notifiers, "poshel nahyi");
    }
    static void NotifyAll(List<INotifier> notifiers, string message)
    {
        foreach (INotifier a in notifiers)
        {
            a.Send(message);
        }
    }
}
public interface INotifier
{
    void Send(string message);
}
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent :{message}");
    }
}

public class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"User sent :{message}");
    }
}
public class PushNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Bro sent :{message}");
    }
}
