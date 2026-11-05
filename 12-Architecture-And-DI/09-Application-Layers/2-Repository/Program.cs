// Files : Repository.cs
public interface IOrderRepository
{
    void Save(Order order);
    IReadOnlyList<Order> GetAll();
}
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    public void Save(Order order)
    {
        _orders.Add(order);
    }
    public IReadOnlyList<Order> GetAll()
    {
        return _orders.AsReadOnly();
    }
}