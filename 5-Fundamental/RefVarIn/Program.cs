using System;
using System.ComponentModel;
using System.Data;
class Program
{
    static void Main()
    {
        List<string> Names = new List<string>(){"Krustu", "Buble", "Nickeins", "Erjan"};
        Console.WriteLine("First look of List or just base List");
        for (var a = 0; a < Names.Count ; a++)
        {
            Console.WriteLine(Names[a]);
        }
        Console.ReadKey();

        ReturnList(Names);
        Console.WriteLine("List After function has finished work");
        for (var a = 0; a < Names.Count; a++)
        {
            Console.WriteLine(Names[a]);
        }
        Console.ReadKey();
    }
    static void ReturnList(List<string> strings)
    {
        strings.Add("Apopa");

        Console.WriteLine("List inside function before creating new list");
        for (var a = 0; a < strings.Count; a++)
        {
            Console.WriteLine(strings[a]);
        }
        Console.ReadKey();



        var ab = new List<string>(strings);
        ab.Add("Pidoras");
        Console.WriteLine("List inside function after creating new list");
        for (var a = 0; a < ab.Count; a++)
        {
            Console.WriteLine(ab[a]);
        }
        Console.ReadKey();
    }
}
/*
 * 1.То же самое с List<string>: (а) добавьте элемент внутри метода, (б) присвойте новый список. Объясните разницу в результатах.

2. Склейте 10 000 строк через += и через StringBuilder. Замерьте Stopwatch. Объясните разницу.

3. Напишите класс с полями decimal? Price и string? Currency. Попробуйте сложить две цены — компилятор не даст. Разберитесь почему.

4. Перепишите цепочку if/else if из 4 веток в switch expression.

5. Напишите метод, возвращающий кортеж (bool ok, string error), и используйте деконструкцию.*/