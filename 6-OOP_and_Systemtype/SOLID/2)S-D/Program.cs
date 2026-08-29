using System;
class Program
{
    static void Main()
    {
        Console.WriteLine();
        OrderCalculator calculator = new OrderCalculator();
        OrderRepository repository = new OrderRepository();
        EmailSender emailSender = new EmailSender();
        var res = new OrderProcessor(emailSender, calculator, repository);

        res.ProcessOrder("Fanta", 14.3m);
        Console.ReadKey();
    }
}
public interface INotificationSender
{
    void Send(string message); //=> Console.WriteLine($"[Email] {message}");
}

public class OrderProcessor
{
    private INotificationSender _sender;
    private OrderCalculator _calculator;
    private OrderRepository _repository;
    public OrderProcessor(INotificationSender sender, OrderCalculator calculator, OrderRepository repository)
    {
        _sender = sender;
        _calculator = calculator;
        _repository = repository;
    }
    public void ProcessOrder(string productName, decimal price)
    {
        decimal total = _calculator.TakeTax(price);
        _repository.SaveOrder(productName, total);
        _sender.Send($"Order {productName} for this amount - {total} usd - has been placed");
    }
}


public class OrderCalculator
{
    private decimal Tax = 1.2m;
    public decimal TakeTax(decimal amount)
    {
        decimal total = amount * Tax;
        return total;
    }

}
public class OrderRepository
{
    public void SaveOrder(string productName, decimal price)
    {
        Console.WriteLine($"[DB] Saving order: {productName} - {price}");
    }

}
public class EmailSender : INotificationSender
{
    public void Send(string email) => Console.WriteLine($"[Email] {email}");
}

public class SmsSender : INotificationSender
{
    public void Send(string sms) => Console.WriteLine($"[User] {sms}");
}



