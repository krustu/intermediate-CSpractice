using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
class Program
{
    static void Main()
    {
        try
        {


            using (var connect = new DatabaseConnection())
            {
                //string? a = null;
                connect.Run();
                bool ans = connect.ExecuteQuery("");
                Console.WriteLine(ans);
            }
            Console.ReadKey();
            using (var connect = new DatabaseConnection())
            {

                connect.Run();
                bool ans = connect.ExecuteQuery("Hi");
                Console.WriteLine(ans);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"error : {ex}");
        }
        finally
        {
            Process();
        }
    }
    public static void Process()
    {
        Console.WriteLine("Roll back variable state");
    }
}
class DatabaseConnection : IDisposable
{
    public void Run()
    {
        Console.WriteLine("Running..>");
    }
    public void Dispose()
    {
        Console.WriteLine("Finishing...");
    }
    public bool ExecuteQuery(string query)
    {
        if (string.IsNullOrEmpty(query))
            throw new ArgumentException("Query cannot be empty");

        Console.WriteLine("Success!");
        return true;

    }
}
