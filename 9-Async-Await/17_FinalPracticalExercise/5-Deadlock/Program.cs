using System;
class Program
{
    static async Task Main()
    {
        await SimpleFunc();

    }
    static async Task<int> AsyncFunc()
    {
        await Task.Delay(1000);
        return 10;
    }
    static async Task SimpleFunc() // just change fo async function 
    {
        var result = await AsyncFunc();
        Console.WriteLine(result);
    }
}
/*static async Task Main()
    {
        SimpleFunc();

    }
    static async Task<int> AsyncFunc()
    {
        await Task.Delay(1000);
        return 10;
    }
    static void SimpleFunc() // just change fo async function 
    {
        try
        {
            var result = AsyncFunc().Result;
            throw new SynchronizationLockException();
        }
        catch (SynchronizationLockException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }*/