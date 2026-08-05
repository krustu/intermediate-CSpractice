using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

class SelectProgram
{
    static void Main()

    {
       List<string> list = new List<string> { "utsurK", "Eblan", "ReltihFloda" };
        var List = list.Select(Reverse).ToList();
        foreach ( var a in List)
        {
            Console.WriteLine(a);
        }


    }


    static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

/*1. Разминка
Дан список чисел { 5, 12, 8, 130, 44 }. Получи новый список, где каждое число увеличено на 10.
List<int> num = new List<int> { 5, 12, 8, 130, 44 };
        var allNum = num.Select(x => x + 10).ToList();

    foreach(var count in allNum)
        {
            Console.WriteLine(count);
        }
    }



2. Строки
Дан список слов { "кот", "собака", "слон", "мышь" }. С помощью Select получи список длин каждого слова (int).
List<string> nam = new List<string> { "кот", "собака", "слон", "мышь" };
        var allNam = nam.Select(x => x.Length).ToList();

    foreach(var count in allNam)
        {
            Console.WriteLine(count);
        }
    }


3. Форматирование
Дан список чисел { 1, 2, 3, 4, 5 }. Преобразуй каждое число в строку вида "Число: X".
List<int> num = new List<int> { 1, 2, 3, 4, 5, };
        var allNum = num.Select(x => $"Number: {x}").ToList();
        foreach(var a in allNum)
        {
            Console.WriteLine(a);
        }

4. Работа с объектами
class Student 
{
    public string Name;
    public int Grade; // оценка от 0 до 100
}
class SelectProgram
{
    static void Main()

    {
        List<Student> students = new List<Student>();
        //var result = collection.Select(x => transformation);
        Student a = new Student { Name = "Krustu", Grade = 85 };
        students.Add(a);
        Student b = new Student { Name = "Eban", Grade = 90 };
        students.Add(b);
        Student c = new Student { Name = "Kser", Grade = 25 };
        students.Add(c);

        Student d = new Student { Name = "Lox", Grade = 90 };
        students.Add(d);

        Student e = new Student { Name = "Hyesos", Grade = 25 };
        students.Add(e);

        Student f = new Student { Name = "Naagibator", Grade = 40 };
        students.Add(f);

        var names = students.Select(x => x.Name).ToList();
        
            foreach (var name in names)
            {


            Console.WriteLine(name);
            }
        

    }
}
public class Student
{
    public string Name {  get; set; }
    public int Grade { get; set; } // оценка от 0 до 100
 
  
}
 Дан List<Student>. Получи список только имён (List<string>).

5. Вычисление на основе объекта
Используя тот же класс Student, получи список строк вида "Иван — сдал" или "Иван — не сдал" (сдал, если Grade >= 60).
class SelectProgram
{
    static void Main()

    {
        List<Student> students = new List<Student>();
        //var result = collection.Select(x => transformation);
        Student a = new Student { Name = "Krustu", Grade = 85 };
        students.Add(a);
        Student b = new Student { Name = "Eban", Grade = 90 };
        students.Add(b);
        Student c = new Student { Name = "Kser", Grade = 25 };
        students.Add(c);

        Student d = new Student { Name = "Lox", Grade = 90 };
        students.Add(d);

        Student e = new Student { Name = "Hyesos", Grade = 25 };
        students.Add(e);

        Student f = new Student { Name = "Naagibator", Grade = 40 };
        students.Add(f);

        var result = students.Select(x => $"{x.Name} - {(x.Grade >= 60 ? "Pass" : "Fail")}").ToList();
        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}
public class Student
{
    public string Name {  get; set; }
    public int Grade { get; set; } // оценка от 0 до 100
 
  
}

6. Индекс элемента
Дан список { "яблоко", "банан", "груша" }. Используя перегрузку Select с индексом, получи список строк "0: яблоко", "1: банан", "2: груша".
 List<string > list = new List<string> { "apple" , "banana", "pear" , "orange"};
        var fruits = list.Select((fruits, index) => $"{index + 1}. {fruits}").ToList();
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

7. Анонимный объект
Дан List<Student>. С помощью Select создай коллекцию анонимных объектов, содержащих только Name и оценку в виде буквы ("A" если Grade >= 90, "B" если >= 75, иначе "C").
class SelectProgram
{
    static void Main()

    {
        List<Student> students = new List<Student>();
        //var result = collection.Select(x => transformation);
        Student a = new Student { Name = "Krustu", Grade = 85 };
        students.Add(a);
        Student b = new Student { Name = "Eban", Grade = 90 };
        students.Add(b);
        Student c = new Student { Name = "Kser", Grade = 25 };
        students.Add(c);

        Student d = new Student { Name = "Lox", Grade = 90 };
        students.Add(d);

        Student e = new Student { Name = "Hyesos", Grade = 25 };
        students.Add(e);

        Student f = new Student { Name = "Naagibator", Grade = 40 };
        students.Add(f);

        var result = students.Select((x, index) =>
        {
            string grade;
            if (x.Grade >= 90)
            {
                grade = "A";

            }
            else if (x.Grade >= 75)
            {
                grade = "B";
            }
            else if (x.Grade >= 50)
            {
                grade = "C";
            }
            else
            {
                grade = "F";
            }
            return $"{index + 1}.{x.Name} - {grade}";
        }).ToList();

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; } // оценка от 0 до 100


}

8. Select + Where
Дан список чисел { 1..20 }. Сначала оставь только чётные числа (Where), а затем возведи их в квадрат (Select).

        int[] numbers = { 1, 2, 3, 4, 5 ,6 ,7, 8, 9, 10, 11, 12, 13 ,14, 15, 16, 17, 18, 19, 20};

        var nums = numbers.Where( x => x % 2 == 0).Select( x => x * x ).ToList();

        foreach( var a in nums)
        {
            Console.WriteLine(a);
        }

9. Со своим методом
Напиши отдельный метод string Reverse(string s), который переворачивает строку. Примени его через Select к списку слов.
class SelectProgram
{
    static void Main()

    {
       List<string> list = new List<string> { "utsurK", "Eblan", "ReltihFloda" };
        var List = list.Select(Reverse).ToList();
        foreach ( var a in List)
        {
            Console.WriteLine(a);
        }


    }


    static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}*/
