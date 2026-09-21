using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
class Program
{
    static async Task Main()
    {
        var Cts = new CancellationTokenSource();
        var checkforans = CountToTenAsync(Cts.Token);

        try
        {

            await Task.Delay(3000);
            Cts.Cancel();

            Console.WriteLine(await checkforans);
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

