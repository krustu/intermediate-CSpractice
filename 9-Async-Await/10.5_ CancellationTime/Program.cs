using System;
class Program
{
    static async Task Main()
    {

        int timesec = 5;
        int CycleNum = 99;
        using var HandMode = new CancellationTokenSource();
        using var AutoTime = new CancellationTokenSource(TimeSpan.FromSeconds(timesec));

        using var combined =
            CancellationTokenSource.CreateLinkedTokenSource(HandMode.Token, AutoTime.Token);



        try
        {
            _ = Task.Run(() =>
            {
                Console.WriteLine("press any key to Cancel Imediatelly");
                Console.ReadKey(true);
                HandMode.Cancel();
            });
            int result = await GetNumber(combined.Token, CycleNum);
            Console.WriteLine($"Result -{result}");
        }
        catch (OperationCanceledException)
        {
            if (HandMode.IsCancellationRequested)
            {
                Console.WriteLine("Operation was cancelled by hand");
            }
            else if (AutoTime.IsCancellationRequested)
            {
                Console.WriteLine("Opeartion was canceled by Timeout");
            }

        }
    }
    static async Task<int> GetNumber(CancellationToken token, int num)
    {
        int amount = 0;
        for (int a = 0; a < num; a++)
        {
            await Task.Delay(400, token);
            amount += num;
            Console.WriteLine($"Current cycle - {a} | status of amount: {amount}");
            token.ThrowIfCancellationRequested();
        }

        return amount;
    }

}
