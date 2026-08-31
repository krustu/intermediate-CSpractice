using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
class Program
{

    static void Main()
    {
        var smser = new List<IMessegeSender>();

        ConsoleMessageSender a1 = new ConsoleMessageSender();
        FileMessageSender a2 = new FileMessageSender();
        FakeSmsMessageSender a3 = new FakeSmsMessageSender();
        smser.Add(a1);
        smser.Add(a2);
        smser.Add(a3);

        var hyina = new NotificationService(smser);
        hyina.Send("Hello");

    }

}
public interface IMessegeSender
{
    void SendMessege(string Message);
}
public class NotificationService
{
    private List<IMessegeSender> senderList;
    public NotificationService(List<IMessegeSender> pidoras)
    {
        senderList = pidoras;
    }
    public void Send(string Message)
    {
        foreach (IMessegeSender sender in senderList)
        {
            try
            {
                sender.SendMessege(Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }

}
public class ConsoleMessageSender : IMessegeSender
{
    public void SendMessege(string Messsage)
    {

        Console.WriteLine($"Send :{Messsage}");
    }
}
public class FileMessageSender : IMessegeSender
{

    public void SendMessege(string Message)
    {
        File.WriteAllText("stm.txt", Message);

        // Console.WriteLine($"[.txt]{Message}");
    }
}

public class FakeSmsMessageSender : IMessegeSender
{
    public void SendMessege(string Message)
    {
        Console.WriteLine($"from Sms - {Message} ");
    }
}

