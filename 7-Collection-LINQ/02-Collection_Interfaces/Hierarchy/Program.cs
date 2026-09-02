using System;
using System.ComponentModel;
class Program
{
    static void Main(string[] args)
    {
        var ShopingCart = new ShoppingCart();
        ShopingCart.AddItem("Item 1");
        ShopingCart.AddItem("Item 2");
        ShopingCart.AddItem("Item 3");


        var itemCount = ShopingCart.CountItems(ShopingCart.GetItems());
        var firstItem = ShopingCart.GetFirst(ShopingCart.GetItems());

        Console.WriteLine($"Total items: {itemCount}");
        Console.WriteLine($"First item: {firstItem}");
        var allItems = ShopingCart.GetItems();
        Console.WriteLine("All items:");
        ShopingCart.PrintAll(allItems);
        Console.ReadKey();
    }

}
public class ShoppingCart
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
    }


    public IReadOnlyList<string> GetItems() => _items;


    public void PrintAll(IEnumerable<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
    public int CountItems(IReadOnlyList<string> list)
    {

        return list.Count;
    }
    public string GetFirst(IReadOnlyList<string> list)
    {
        return list[0];
    }
}
