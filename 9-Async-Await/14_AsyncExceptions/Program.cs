using System;
class Program
{
    static async Task Main()
    {

        try
        {
            Task a1 = Task.Run(() => { throw new InvalidOperationException("Mistake 1"); });
            Task a2 = Task.Run(() => { throw new ArgumentException("Mistake 2"); });
            Task a3 = Task.Run(() => {

                Thread.Sleep(1000);
                Console.WriteLine("Successfuly done!");
            });
            //Without await
            Task.WaitAll(a1, a2, a3);
        }
        catch (AggregateException ex)
        {
            foreach (var a in ex.InnerExceptions)
            {
                Console.WriteLine(a.Message);
            }
        }


    }
}

/*   static async Task Main()
    {
        Task a1 = Task.Run(() => { throw new InvalidOperationException("Mistake 1"); });
        Task a2 = Task.Run(() => {  throw new ArgumentException("Mistake 2"); });
        Task a3 = Task.Run(() =>
        {
         
            Thread.Sleep(1000);
            Console.WriteLine("Successfuly done!");
        });
        try
        {
           

            await Task.WhenAll(a2, a1, a3);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
        }
    }*/
