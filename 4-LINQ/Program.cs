using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("here LINQ with more or less");
       List<int> numbers = new List<int> {1,2,3,4 , 11, 12, 3, 34, 25, 36, 721, 38, 92, 10 };

        var Result1 = numbers.Where(x => x > 5);

        foreach (var a in Result1)
        {
            Console.WriteLine(a);
        }



        Console.WriteLine("Even numbers ");

          var Result2 = numbers.Where(x => x % 2 == 0);
          foreach (var b in Result2)
          {
              Console.WriteLine(b);
          }
        Console.WriteLine(" Odd numbers");

        var Result3 = numbers.Where(x => x % 2 != 0).ToList();
        for(int i = 0; i < Result3.Count; i++)
        {
            Console.WriteLine(Result3.ElementAt(i));
        }
        



        Console.WriteLine("lines more than 4 words");
        var words = new List<string> { "hello world", "this is a test", "C# is great", "LINQ is powerful", "short" };

        var results4 = words.Where(w => w.Length > 4).ToList();
        foreach( var l in results4)
        {
            Console.WriteLine(l);
        }

        Console.WriteLine("with for");
        Console.ReadKey();
        for (int k = 0; k < results4.Count; k++)
        {
                        Console.WriteLine(results4.ElementAt(k));
        }

        Console.WriteLine("object properties");



        Console.WriteLine("double conditions");

        // for Arrays

        /*for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}*/

        // for Lists

        /*for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine(numbers[i]);
}*/


        /*
         * for (int i = 0;      // начинаем с первого элемента
     i < numbers.Count; // пока не дошли до конца
     i++)            // после каждой итерации i = i + 1
{
    Console.WriteLine(numbers[i]);
}*/
        /**/
        /**/
    }
}