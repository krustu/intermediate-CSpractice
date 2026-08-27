using System;

class Program
{
    static void Main()
    {
        using (var logger = new FileLogger("app.log"))
        {


            logger.Log("smt");

        }


        Console.ReadKey();

        using (FileLogger logger2 = new FileLogger("app.log"))
        {
            logger2.Log("hello everyone");
        }






    }
}

public class FileLogger : IDisposable
{
    private string _fileName;

    public FileLogger(string fileName)
    {
        _fileName = fileName;
        Console.WriteLine($"file {_fileName} open");
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{_fileName}] {message}");
    }

    public void Dispose()
    {
        Console.WriteLine($"File {_fileName} closed");
    }
}
