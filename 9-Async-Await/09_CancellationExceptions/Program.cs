using System;
using System.Reflection;
class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();
        //TimeSpan.FromSeconds(2)
        var a = GoodWorkerAsync(cts.Token);

        await Task.Delay(2000); // adjustment time 

        cts.Cancel();
        Console.WriteLine("Operation has been closed");

        //Incorrect version
        await Task.Delay(1000);

        var cts2 = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await BadWorkerAsync(cts2.Token);


    }
    static async Task GoodWorkerAsync(CancellationToken token)
    {
        for (int a = 0; a < 20; a++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"step - {a}");
            await Task.Delay(300, token);

        }
    }
    static async Task BadWorkerAsync(CancellationToken token)
    {
        for (int a = 0; a < 20; a++)
        {
            //without writing - title.ThrowIfCancellationRequested();
            Console.WriteLine($"step - {a}");
            await Task.Delay(300);//, token)

        }
        Console.WriteLine("Program successfuly has done without any stopping");
    }


}