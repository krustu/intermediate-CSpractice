// Files : Service.cs
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Order Place(string product, decimal price)
    {
        if (string.IsNullOrWhiteSpace(product))
        {
            throw new ArgumentException("Product name cannot be empty.", nameof(product));
        }
        if (price <= 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }

        var order = new Order { Id = _orderRepository.GetAll().Count + 1, Product = product, Price = price };
        _orderRepository.Save(order);
        return order;
    }
    public decimal TotalSum() => _orderRepository.GetAll().Sum(o => o.Price);
}
