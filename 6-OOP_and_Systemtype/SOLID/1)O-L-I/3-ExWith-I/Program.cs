using System;
using System.Security.Cryptography;
class Program
{
    static void Main()
    {
        List<IWorker> workers = new List<IWorker>
        {
            new Janitor(),
            new Developer(),
            new Janitor(),
            new Developer()
        };
        foreach (var a in workers)
        {
            a.Worker();
        }
        // ICodeReviewer 
        // it works only if you now where excalty object Developer placed
        ICodeReviewer developer = (ICodeReviewer)workers[1];
        developer.CodeReview();
        //another method to use function of class Developer 
        //this way more safety to use in big project 
        if (workers[3] is ICodeReviewer develop)
        {
            develop.CodeReview();
        }

        Console.ReadKey();
    }
}

public interface ICodeReviewer
{
    void CodeReview();
}
public interface IWorker
{
    void Worker();
}

class Janitor : IWorker
{
    public void Worker()
    {
        Console.WriteLine("Janitor is working");
    }

}
class Developer : IWorker, ICodeReviewer
{
    public void CodeReview()
    {
        Console.WriteLine("Developer is debugging");
    }

    public void Worker()
    {
        Console.WriteLine("Developer is working");
    }
}
