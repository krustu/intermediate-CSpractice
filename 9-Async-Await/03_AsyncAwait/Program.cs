using System;
class Program
{
    static async Task Main()
    {
        try
        {
            //await DoWorkAsync();
            await DoWorkVoid(); // cannot await void should be Task
        }
        catch (InvalidOperationException ex)
        {
            if (ex.StackTrace.Contains(nameof(DoWorkAsync)))
            {
                Console.WriteLine($"DoWorkAsync is broken - {ex.Message}");
            }
            else if (ex.StackTrace.Contains(nameof(DoWorkVoid)))
            {
                Console.WriteLine($"DoWorkVoid is broken - {ex.Message}");
            }
        }
    }
    static async Task DoWorkAsync()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("Sorry, smt wrong inside TAsk");
    }
    static async void DoWorkVoid()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("Sorry, smt wrong inside Void");
    }
}