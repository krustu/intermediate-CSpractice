using System;
class Program
{
    static void Main()
    {
        var p1 = new Product("Book");
        var p2 = new Product("Laptop", 1000);
        var p3 = new Product("Phone", 800, "Electronics");

        Console.WriteLine($"{p1.Name} - {p1.Price} - {p1.Category}");
        Console.WriteLine($"{p2.Name} - {p2.Price} - {p2.Category}");
        Console.WriteLine($"{p3.Name} - {p3.Price} - {p3.Category}");
    }
}
public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public string Category { get; }

    public Product(string name) : this(name, 0, "Uncategorized") { }
    public Product(string name, decimal price) : this(name, price, "Uncategorized") { }
    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    // конструктор 1: (string name) — вызывает конструктор 3, Price = 0, Category = "Uncategorized"
    // конструктор 2: (string name, decimal price) — вызывает конструктор 3, Category = "Uncategorized"
    // конструктор 3: (string name, decimal price, string category) — основной, тут реальная логика присвоения всех трёх полей
}
