using System;
using System.Diagnostics;
class Prgram
{
    static async Task Main()
    {
        int num = 5;
        var time = new Stopwatch();

        for (int a = 0; a < 5; a++)
        {
            time.Restart();

            var Version1 = await ChainedAsync(num);

            time.Stop();
            Console.WriteLine($"Fisrt - Async chain bad : {time.ElapsedMilliseconds}");

            time.Restart();

            var Version2 = await GoodChainedAsync(num);
            time.Stop();
            Console.WriteLine($"Fisrt - Async chain Good :{time.ElapsedMilliseconds}");
        }


    }
    static async Task<int> ChainedAsync(int a)
    {
        await Task.Delay(1000);
        var result = await ChainedAsync1(a);
        return result * 5;
    }
    static async Task<int> ChainedAsync1(int a)
    {
        await Task.Delay(1000);
        var result = await ChainedAsync2(a);
        return result * 3;
    }
    static async Task<int> ChainedAsync2(int a)
    {
        await Task.Delay(1000);
        int amount = a * 10;
        var result = ChainedAsync3().Result;
        return amount *= result;
    }
    static async Task<int> ChainedAsync3()
    {
        int answer = 10;
        await Task.Delay(1000);
        return answer * 10;
    }
    //--------------------------------------------------------------------------------------------
    static async Task<int> GoodChainedAsync(int a)
    {
        await Task.Delay(1000);
        var result = await GoodChainedAsync1(a);
        return result * 5;
    }
    static async Task<int> GoodChainedAsync1(int a)
    {
        await Task.Delay(1000);
        var result = await GoodChainedAsync2(a);
        return result * 3;
    }
    static async Task<int> GoodChainedAsync2(int a)
    {
        await Task.Delay(1000);
        int amount = a * 10;
        var result = await GoodChainedAsync3();
        return amount *= result;
    }
    static async Task<int> GoodChainedAsync3()
    {
        int answer = 10;
        await Task.Delay(1000);
        return answer * 10;
    }
}
