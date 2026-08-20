using System;
class Program
{
    static void Main()
    {
        int Number = 10;
        object RefNumber = Number;
        Number += 10;
        Number = (int)RefNumber;
        Number += 10;
        Console.WriteLine(Number);
        Console.WriteLine(RefNumber);









        Console.ReadKey();
    }
}