using System;
using System.Net.Sockets;
class Program
{
    static void Main()
    {

        Console.WriteLine("With using If else");
        int score = 0;
        string result;
        if ( score >= 80)
        {
            result = "excellent";
        }
        else if( score >= 60)
        {
            result = "Good ";
        }
        else if (score >= 40)
        {
            result = "Not bad";
        }
        else
        {
            result = "Dumb";
   
        }

        Console.WriteLine($"You are - {result}");
        Console.ReadKey();

        Console.WriteLine("With using Switch");
        string grade = score switch
        {
            >= 80 => "God",
            >= 60 => "good",
            >= 40 => "Norm",
            _ => "Idiot"
        };
        Console.WriteLine($"You are - {grade}");
        Console.ReadKey();
    }
}