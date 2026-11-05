class Proram
{
    // Files : ApplicationEntryPoint.cs
    static void Main()
    {

        var repository = new InMemoryOrderRepository();
        var service = new OrderService(repository);
        service.Place("Fantasy Book", 19.99m);
        service.Place("Science Fiction Book", 24.99m);
        service.Place("Mystery Book", 14.99m);

        try { service.Place("", 0m); }                                   // только он под try
        catch (ArgumentException ex) { Console.WriteLine($"Rejected: {ex.Message}"); }

        Console.WriteLine($"Total sum of orders: {service.TotalSum():C}");   // сумма должна напечататься
        foreach (var order in repository.GetAll())
        {
            Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product}, Price: {order.Price:C}");
        }




    }
}
