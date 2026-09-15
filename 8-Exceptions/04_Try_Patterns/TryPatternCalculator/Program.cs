using System;
using System.ComponentModel.DataAnnotations;
class Program
{
    static void Main()
    {
        Menu.MainMenu();
    }
}
public static class InputHelper
{
    public static double ReadDouble(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double number))
            {
                return number;
            }

            Console.WriteLine("Invalid Number.");

        }
    }
}
public static class Menu
{
    public static Dictionary<string, string> commands = new()
    {
        { "help" , "Available operations: + - * /"},
        {"exit" , "Exiting colculator..." }
    };
    public static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine(" Calculator");
            Console.WriteLine(" 1 - Plus");
            Console.WriteLine(" 2 - Minus");
            Console.WriteLine(" 3 - Divide");
            Console.WriteLine(" 4 - Multiple");

            string? input = Console.ReadLine();

            if (commands.TryGetValue(input ?? "", out string? message))
            {
                Console.WriteLine(message);

                if (input == "exit")
                    return;

                continue;
            }

            if (!int.TryParse(input, out int answer))
            {
                Console.WriteLine("Invalid operation.");
                continue;
            }

            switch (answer)
            {
                case 1:
                    double a = InputHelper.ReadDouble("Enter first number: ");
                    double b = InputHelper.ReadDouble("Enter second number: ");

                    Calculator calculator = new Calculator();
                    calculator.Plus(a, b);
                    break;

                case 2:
                    double aa = InputHelper.ReadDouble("Enter first number: ");
                    double bb = InputHelper.ReadDouble("Enter second number: ");

                    Calculator calculator1 = new Calculator();
                    calculator1.Minus(aa, bb);
                    break;


                case 3:
                    double aaa = InputHelper.ReadDouble("Enter first number: ");
                    double bbb = InputHelper.ReadDouble("Enter second number: ");

                    Calculator calculator2 = new Calculator();
                    calculator2.Divide(aaa, bbb);
                    break;


                case 4:
                    double aaaa = InputHelper.ReadDouble("Enter first number: ");
                    double bbbb = InputHelper.ReadDouble("Enter second number: ");

                    Calculator calculator3 = new Calculator();
                    calculator3.Multiple(aaaa, bbbb);
                    break;


                default:
                    Console.WriteLine("Choose 1-4.");
                    break;
            }

        }


        // InputHelper.ReadDouble()
    }
}

public class Calculator
{
    public double Divide(double a, double b)
    {
        var answer = a / b;

        Console.WriteLine($"{answer}");
        return answer;
    }
    public double Multiple(double a, double b)
    {
        var answer = a * b;

        Console.WriteLine($"{answer}");
        return answer;
    }
    public double Plus(double a, double b)
    {
        var answer = a + b;

        Console.WriteLine($"{answer}");
        return answer;
    }
    public double Minus(double a, double b)
    {
        var answer = a - b;

        Console.WriteLine($"{answer}");
        return answer;
    }
}
