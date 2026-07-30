using System;
class Program
{
    static List<int> numbers = new List<int>();
    static void Main(string[] args)
    {
       





        InputNumber();
        Menu();
        



    }
    public static void Menu()
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. OrderByDescending");
            Console.WriteLine("2. OrderBy");
            Console.WriteLine("3. Your List of Numbers");
            Console.WriteLine("4. Show basic structure code");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = INput();
            switch (choice)
            {
                case "1":
                    OrderByDescending();
                    break;
                case "2":
                    OrderBy();
                    break;
                case "3":
                    showNumbers();
                    break;
                case "4":
                    showCode();
                    break;
                case "5":
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
       

    }
    public static void showCode()
    {
        Console.Clear();
        Console.WriteLine("Basic structure code:");
        Console.WriteLine("""
            var numbers = new[] { 5, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, };\r\n       
            var sorted = numbers.OrderBy(x => x).ToList();\r\n        
            foreach( var a in sorted)\r\n         
            {\r\n             
                      Console.WriteLine(a);\r\n         
            }"):
            """);

        Console.WriteLine("click to return to the menu");
        Console.ReadKey();

    }
    public static void showNumbers()
    {
                Console.Clear();
        Console.WriteLine("all added numbers are: "); // fucntion of delete
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("click to return to the menu");
        Console.ReadKey();
    }
    public static string INput()
    {
        while (true)
        {
            Console.Write("");
            string ?choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Please try again.");

            }
        }
    }

    public static void InputNumber()
    {
        Console.WriteLine("please add 10 numbers to the list: ");
        for (int i = 0; i < 10; i++)
        {


            while (true)
            {

                int numbers;

                if (int.TryParse(Console.ReadLine(), out numbers))
                {

                    Program.numbers.Add(numbers);
                    Console.Clear();
                    Console.WriteLine("Numbers added successfully.");
                    Console.WriteLine($" {9 - i} Left ");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }
    public static void OrderBy()
    {
        Console.Clear();
        
        var sorted = numbers.OrderBy(x => x).ToList();
        Console.WriteLine("Here is the list of numbers sorted in ascending order:");
        foreach(var a in sorted)
        {
            Console.WriteLine(a);
        }
        Console.WriteLine("click to return to the menu");
        Console.ReadKey();
    }
    public static void OrderByDescending()
    {
        Console.Clear();
        var sorted = numbers.OrderByDescending(x => x).ToList();
        Console.WriteLine("Here is the list of numbers sorted in descending order:");
        foreach(var a in sorted)
        {
            Console.WriteLine(a);
        }
        Console.WriteLine("click to return to the menu");
        Console.ReadKey();
    }
    
}
/*Console.WriteLine("Here is the list of numbers sorted in ascending order:");
        Console.WriteLine("Current condition of the array (5, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, ) ");

        var numbers = new[] { 5, 3, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, };
      var sorted = numbers.OrderBy(x => x).ToList();
        foreach( var a in sorted)
        {
            Console.WriteLine(a);
        }*/