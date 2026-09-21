using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        var Cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        try
        {
            var checkforans = await CountToTenAsync(Cts.Token);

            Console.WriteLine(checkforans);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operationg has been canceled");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Closing...");
        }
    }
    static async Task<string> CountToTenAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"step - {i}");
            await Task.Delay(500, token);

        }
        return "Finish";
    }
}