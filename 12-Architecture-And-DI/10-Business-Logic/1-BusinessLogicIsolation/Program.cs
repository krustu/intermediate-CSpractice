using System;
class Program
{
    static void Main()
    {
        PriceService priceService = new PriceService(new PriceSource());
        PriceService httpService = new PriceService(new HttpPriceSource());

        var ans = httpService.GetDiscountedPrice("ProductA");
        var ans2 = priceService.GetDiscountedPrice("ProductB");
        Console.WriteLine($"Discounted price from HttpPriceSource: {ans}");
        Console.WriteLine($"Discounted price from PriceSource: {ans2}");
    }
}
public interface IPriceSource
{
    decimal GetPrice(string product);
}

public class PriceService
{
    private readonly IPriceSource _source;
    public PriceService(IPriceSource source) { _source = source; }

    public decimal GetDiscountedPrice(string product)
    {
        decimal price = _source.GetPrice(product);
        return price > 100 ? price * 0.9m : price;
    }
}

public class PriceSource : IPriceSource
{
    public decimal GetPrice(string product)
    {
        if (product == null && product == "")
        {
            throw new ArgumentException("Product name cannot be null or empty.");
        }
        decimal price = 200;
        return price;
    }
}
public class HttpPriceSource : IPriceSource
{
    public decimal GetPrice(string product)
    {
        // Simulate fetching price from an HTTP source
        if (string.IsNullOrEmpty(product))
        {
            throw new ArgumentException("Product name cannot be null or empty.");
        }
        decimal price = 150; // Simulated price
        return price;
    }
}
