using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        try
        {




            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));

            var res = await GoodWorkerAsync(cts.Token, Data.names);

        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine(ex.GetType().Name);
            Console.WriteLine(ex.Message);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.GetType().Name);
            Console.WriteLine(ex.Message);
        }
    }
    static async Task<string> GoodWorkerAsync(CancellationToken token, string[] data)
    {
        foreach (var a in data)
        {
            Console.WriteLine(a);
            token.ThrowIfCancellationRequested();
            await Task.Delay(200); //wihtout token
                                   // token.ThrowIfCancellationRequested();
        }
        return "kok";
    }
}
public static class Data
{
    public static string[] names =
{
    "James",
    "John",
    "Michael",
    "David",
    "Robert",
    "William",
    "Daniel",
    "Matthew",
    "Joseph",
    "Christopher",
    "Andrew",
    "Joshua",
    "Anthony",
    "Ryan",
    "Thomas",
    "Emma",
    "Olivia",
    "Sophia",
    "Isabella",
    "Ava",
    "Mia",
    "Emily",
    "Charlotte",
    "Amelia",
    "Harper",
    "Ella",
    "Grace",
    "Lily",
    "Chloe",
    "Sofia"
};
}