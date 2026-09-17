using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
class Program
{
    static void Main()
    {
        try
        {
            var User1 = new NotificationService(DataMessanger.CurrentDataSender);

            User1.Send("Hi my friend");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
public interface IMessegeSender
{
    void SendText(string a);
}

public static class DataMessanger
{
    public static List<IMessegeSender> CurrentDataSender = new()
    {
        new ConsoleMessageSender(),
        new FileMessageSender(),
        new FakeSmsMessageSender(),
        new NickMessanger()
    };

}
public class NotificationService
{
    private List<IMessegeSender> texts = new();
    public NotificationService(List<IMessegeSender> texts)
    {
        this.texts = texts;
    }
    public void Send(string Message)
    {
        var successList = new List<string>();
        var failList = new List<string>();
        try
        {
            if (Message == null)
                throw new ArgumentNullException(nameof(Message));
            if (Message == "")
                throw new ArgumentException(nameof(Message));

            foreach (IMessegeSender a in texts)
            {
                try
                {
                    a.SendText(Message);
                    successList.Add(a.GetType().Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    failList.Add($"{a.GetType().Name}: {ex.Message}");
                }
            }
            Console.WriteLine("\n--- Report ---");
            Console.WriteLine($"Success: {string.Join(", ", successList)}");
            Console.WriteLine($"Fail: {(failList.Any() ? string.Join("; ", failList) : "no Disruptions")}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

}
public class ExceptionStupidName : Exception
{
    public string Name { get; }

    public ExceptionStupidName(string Name) : base($"Dear user You have very stupid name {Name} please change it or delete our app")
    {
        this.Name = Name;
    }
}
public class ConsoleMessageSender : IMessegeSender
{
    public string Name = "Gay";
    public void SendText(string Message)
    {
        try
        {
            if (Name != "Gay")
            {
                Console.WriteLine($"\n# User: {Name} send - {Message}");
            }
            else
            {
                throw new ExceptionStupidName(nameof(Name));
            }
        }
        catch (ExceptionStupidName ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            Console.WriteLine("Program finishing...");
        }
    }
}
public class FileMessageSender : IMessegeSender
{
    private void Done(string text)
    {
        Console.WriteLine($"\n txt.{text} is successfuly converted");
    }
    public void SendText(string Message)
    {
        try
        {
            if (Message.Length < 3)
                throw new ArgumentException("Please Write more than 3 letter", nameof(Message));

            File.WriteAllText("", Message);

            Done(Message);
        }

        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            Console.WriteLine("Program finishing...");
        }


    }
}
public class FakeSmsMessageSender : IMessegeSender
{
    public void SendText(string Message)
    {
        if (Message != null && Message != "")
        {
            Console.WriteLine($"\nSpam? - {Message}");
            Console.WriteLine("Porgram finishing...");
        }


        else
        {
            Console.WriteLine("\nSpam : nothing send..");
        }

    }
}
public class NickMessanger : IMessegeSender
{
    private string Nickbro = "";
    public void SendText(string a)
    {
        try
        {
            if (Nickbro == "")
            {
                Nickbro = "Anonimus";
            }
            Console.WriteLine($"\n@{Nickbro} sent :{a}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            Console.WriteLine("Porgram finishing...");
        }

    }
}
