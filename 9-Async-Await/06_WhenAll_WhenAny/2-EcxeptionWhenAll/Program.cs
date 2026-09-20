using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        int number = 20;

        Task<int> a = NormalFunc(number);
        Task<int> b = BugFunc(number);
        Task<int> c = NormalFunc2(number);
        Task<int> d = NormalFunc3(number);
        Task<int> e = NormalFunc4(number);
        try
        {
            IEnumerable<int> collection =
                await Task.WhenAll(a, b, c, d, e);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        foreach (var p in new[] { a, b, c, d, e })
        {
            if (p.IsCompletedSuccessfully)
                Console.WriteLine(p.Result);
        }

    }
    static async Task<int> NormalFunc(int a)
    {
        await Task.Delay(6000);
        var result = a * a;
        return result;
    }
    static async Task<int> NormalFunc2(int a)
    {
        await Task.Delay(3330);
        var result = a * 2;
        return result;
    }
    static async Task<int> NormalFunc3(int a)
    {
        await Task.Delay(10);
        var result = a * 4;
        return result;
    }
    static async Task<int> NormalFunc4(int a)
    {
        await Task.Delay(5000);
        var result = a * 6;
        return result;
    }
    static Task<int> BugFunc(int a)
    {

        return Task.Run(() =>
        {
            Thread.Sleep(1000);
            var result = a / 0;
            return result;

        });



    }

}
