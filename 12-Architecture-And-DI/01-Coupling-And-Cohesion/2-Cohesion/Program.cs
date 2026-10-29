using System;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static void Main()
    {
        decimal[] Purhcase = { 1.5m, 2.7m, 3.2m, 4.1m, 5.9m, 6.3m, 7.8m, 8.4m, 9.6m, 10.2m };

        var dataCenter = new DataCenter();
        OrderHistory histiry = new();
        var culcate1 = new CalculateSum(dataCenter);
        var saverecipte = new SaveReceipt(histiry);
        var ShowAll = new ShowReceipt(histiry);

        decimal answer = culcate1.Calculate(Purhcase);
        saverecipte.SaveToList(answer);
        ShowAll.ShowInfo();

    }
}
class OrderHistory
{
    private readonly List<string> _lines = new();
    public void Add(string line) => _lines.Add(line);
    public IReadOnlyList<string> GetAll() => _lines;   // список «только для чтения»: смотреть можно, менять нельзя
}
class DataCenter
{
    public const decimal Tax = 0.85m;
    public const decimal CustomsTax = 0.8m;
    public void SimpleTax(ref decimal sum)
    {
        sum /= Tax;
    }
    public void FullTax(ref decimal sum)
    {
        sum /= Tax;
        sum /= CustomsTax;
    }
}
class CalculateSum
{
    private DataCenter _dataCenter;
    public CalculateSum(DataCenter a)
    {
        _dataCenter = a;
    }
    public decimal Calculate(decimal[] products)
    {
        decimal result = 0;
        for (int a = 0; a < products.Length; a++)
        {
            result += products[a];
        }


        _dataCenter.FullTax(ref result);

        return result;
    }
}
class ShowReceipt
{
    private OrderHistory _Order;
    public ShowReceipt(OrderHistory _Order)
    {
        this._Order = _Order;
    }
    public void ShowInfo()
    {

        Console.WriteLine("All Purchase:");
        foreach (var a in _Order.GetAll())
        {
            Console.WriteLine(a);
        }


    }



}
class SaveReceipt
{
    private OrderHistory _Order;
    public SaveReceipt(OrderHistory _Order)
    {
        this._Order = _Order;
    }
    private int index = 1;
    public void SaveToList(decimal receipt)
    {


        string message = $"{index}.Last purchase was a : {receipt}";

        _Order.Add(message);

        index += 1;
    }
}


