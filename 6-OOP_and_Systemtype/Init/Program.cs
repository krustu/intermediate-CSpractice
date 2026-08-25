using System;
class Program
{
    static void Main()
    {


        Order order = new Order { ProductName = "Laptop", Price = 1000, Quantity = 3 };

        Console.WriteLine(order.Total);


        order.Price = 1500;
        Console.WriteLine(order.Total);
        Console.ReadKey();

        /*
     
Выведи order.Total
Попробуй специально написать order.ProductName = "Другое название"; после создания — убедись, что компилятор выдаст ошибку из-за init, покажи мне текст ошибки
Измени order.Price на другое значение и снова выведи order.Total — убедись, что число пересчиталось само, без дополнительного кода с твоей стороны

Смысл — почувствовать разницу между "хранимым" значением (Price, можно менять) и "вычисляемым" (Total, всегда актуально автоматически).*/
    }
}
public class Order
{
    public string ProductName { get; init; } // задаётся один раз при создании
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal Total => Price * Quantity; // вычисляемое свойство
}