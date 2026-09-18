using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        int answerInt = CalculateSquare(5);
        Console.WriteLine(answerInt); // 25

        Task<int> answer = CalculateSquareAsync(5);
        Console.WriteLine(answer.IsCompleted); // false

        int result = answer.Result;
        Console.WriteLine(result); // 25
        Console.WriteLine(answer.Result);

        Console.WriteLine(answer.IsCompleted); // true
    }

    public static Task<int> CalculateSquareAsync(int number)
    {

        return Task.Run(() =>
        {
            Thread.Sleep(3000);
            int result = number * number;
            return result;
        });


    }
    public static int CalculateSquare(int number)
    {
        var result = number * number;
        return result;
    }
}
