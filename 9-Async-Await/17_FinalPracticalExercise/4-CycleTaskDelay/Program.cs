using System;
class Program
{
    static async Task Main()
    {
        using var HandMod = new CancellationTokenSource(TimeSpan.FromSeconds(1));

        try
        {
            await Numerable(2, HandMod.Token);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Program closing...");
        }
    }
    static async Task Numerable(int count, CancellationToken token)
    {
        for (int a = 0; a < count; a++)
        {
            await Task.Delay(5000, token);
            token.ThrowIfCancellationRequested();
        }
    }
}