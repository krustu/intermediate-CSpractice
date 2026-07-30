using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {

        Console.ReadKey();
        Console.WriteLine("here LINQ with more or less (1,2,3,4 , 11, 12, 3, 34, 25, 36, 721, 38, 92, 10 ) ");
       List<int> numbers = new List<int> {1,2,3,4 , 11, 12, 3, 34, 25, 36, 721, 38, 92, 10 };

        var Result1 = numbers.Where(x => x > 5);

        foreach (var a in Result1)
        {
            Console.WriteLine(a);
        }


        Console.ReadKey();
        Console.WriteLine("Even numbers (1,2,3,4 , 11, 12, 3, 34, 25, 36, 721, 38, 92, 10 ) ");

          var Result2 = numbers.Where(x => x % 2 == 0);
          foreach (var b in Result2)
          {
              Console.WriteLine(b);
          }
        Console.ReadKey();
        Console.WriteLine(" Odd numbers(1,2,3,4 , 11, 12, 3, 34, 25, 36, 721, 38, 92, 10 ) ");

        var Result3 = numbers.Where(x => x % 2 != 0).ToList();
        for(int i = 0; i < Result3.Count; i++)
        {
            Console.WriteLine(Result3.ElementAt(i));
        }



        Console.ReadKey();
        Console.WriteLine("lines more than 4 words (\"hello world\", \"this is a test\", \"C# is great\", \"LINQ is powerful\", \"short\") ");
        var words = new List<string> { "hello world", "this is a test", "C# is great", "LINQ is powerful", "short" };

        var results4 = words.Where(w => w.Length > 4).ToList();
        foreach( var l in results4)
        {
            Console.WriteLine(l);
        }
        Console.ReadKey();
        Console.WriteLine("with for (\"hello world\", \"this is a test\", \"C# is great\", \"LINQ is powerful\", \"short\") ");
        Console.ReadKey();
        for (int k = 0; k < results4.Count; k++)
        {
                        Console.WriteLine(results4.ElementAt(k));
        }

        Console.ReadKey();
        Console.WriteLine("object properties() ");
        var peaple = new[]
        {
            new { Name = "Alice"  , Age = 30 },
            new { Name = "Bob",     Age =  5 },
            new { Name = "Charlie", Age = 35 },
            new { Name = "Alice"  , Age = 10 },
            new { Name = "Boba",    Age = 15 },
            new { Name = "Char",    Age = 33 },
            new { Name = "Alie"  ,  Age = 10 },
            new { Name = "Bobobe",  Age = 22 },
            new { Name = "Karlie",  Age = 5  }

        };
        var result5 = peaple.Where(X => X.Age > 10).ToList();
        foreach (var p in result5)
        {
            Console.WriteLine(p);
        }







        Console.ReadKey();
        Console.WriteLine("double conditions() ");

        var result6 = peaple.Where(x => x.Age >= 10 && x.Name.StartsWith("A")).ToList();
        foreach (var o in result6)
        {
            Console.WriteLine(o);
        } Console.ReadKey();


















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