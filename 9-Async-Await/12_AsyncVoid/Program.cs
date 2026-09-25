using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        try
        {
            await GoodMethod();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            BadMethod();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static async Task GoodMethod()
    {
        await Task.Delay(500);
        throw new Exception("From task");
    }
    static async void BadMethod()
    {
        await Task.Delay(500);
        throw new Exception("From void");
    }
}
