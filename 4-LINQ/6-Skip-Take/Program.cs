using System;
using System.Runtime.InteropServices;
class skipTake
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var result = numbers.Skip(5).Take(5).Select(x => x * x);
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
    }
}

/*Задания на Skip / Take

1. Разминка
Дан список { 10, 20, 30, 40, 50, 60, 70 }. Пропусти первые 3 элемента и выведи оставшиеся.

 List<int> num = new List<int> { 2, 4, 6, 7, 8, 10 };
        var result = num.Skip(3);
        foreach (var n in result)
        {
            Console.WriteLine(n);
        }
INPUT: 7, 8, 10

2. Take
Тот же список. Возьми только первые 4 элемента.
 List<int> num = new List<int> { 2, 4, 6, 7, 8, 10 };
        var result = num.Take(4);
        foreach (var n in result)
        {
            Console.WriteLine(n);
        }

3. Пагинация
Дан список из 10 студентов (Student, Name, Grade). Реализуй вывод "страницы 2" при размере страницы 3 (то есть элементы с 4-го по 6-й).
List<Student> students = new List<Student>();
        Student a = new Student { Name = "Krustu", Grade = 85 };
        students.Add(a);
        Student b = new Student { Name = "Eban", Grade = 90 };
        students.Add(b);
        Student c = new Student { Name = "Kser", Grade = 25 };
        students.Add(c);
        Student d = new Student { Name = "Lox", Grade = 95 };
        students.Add(d);
        Student e = new Student { Name = "Hyesos", Grade = 15 };
        students.Add(e);
        Student f = new Student { Name = "Naagibator", Grade = 2 };
        students.Add(f);
        Student g = new Student { Name = "Kse223fr", Grade = 25 };
        students.Add(g);
        Student h = new Student { Name = "Lox", Grade = 9 };
        students.Add(h);
        Student i = new Student { Name = "Hys", Grade = 100 };
        students.Add(i);
        Student j = new Student { Name = "ibator", Grade = 40 };
        students.Add(j);

        var page2 = students.Skip(3).Take(3);
        foreach (var student in page2)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
        }

4. Выход за границы
Дан список из 5 элементов. Попробуй сделать Skip(10) и Take(10). Проверь на практике — будет ли исключение, и что окажется в результате.
 List<string> num = new List<string> {"1", "2", "3", "4", "5" };
        var res = num.Skip(10).Take(10);
        foreach (var a in res)
        {
            Console.WriteLine(a);
        }
Input : (ничего не выводится, исключения нет)

5. SkipWhile / TakeWhile
Дан список { 1, 2, 3, 10, 4, 5 }. Используй TakeWhile, чтобы взять числа, пока они меньше 5. Сравни результат с Where(x => x < 5) — почему они отличаются?
List<int> num = new List<int> { 1, 2, 3, 10, 4, 5 };
        var result = num.TakeWhile(x => x < 5); 
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
        Console.WriteLine(" with Where:");

        var result2 = num.Where(x => x < 5);
        foreach (var a in result2)
        {
            Console.WriteLine(a);
        } 
Input : 1, 2, 3 TakeWhile - take numbers step by step until the condition is false.(1,2,3,4) Where - take all numbers that satisfy the condition. 

6. Комбинация с OrderBy
Дан список Student. Отсортируй по Grade по убыванию (OrderByDescending) и с помощью Take(3) выведи топ-3 студента.
 List<Student> students = new List<Student>();
        Student a = new Student { Name = "Krustu", Grade = 85 };
        students.Add(a);
        Student b = new Student { Name = "Eban", Grade = 90 };
        students.Add(b);
        Student c = new Student { Name = "Kser", Grade = 25 };
        students.Add(c);
        Student d = new Student { Name = "Lox", Grade = 95 };
        students.Add(d);
        Student e = new Student { Name = "Hyesos", Grade = 15 };
        students.Add(e);
        Student f = new Student { Name = "Naagibator", Grade = 2 };
        students.Add(f);
        Student g = new Student { Name = "Kse223fr", Grade = 25 };
        students.Add(g);
        Student h = new Student { Name = "Lox", Grade = 9 };
        students.Add(h);
        Student i = new Student { Name = "Hys", Grade = 100 };
        students.Add(i);
        Student j = new Student { Name = "ibator", Grade = 40 };
        students.Add(j);

        var Sort = students.OrderByDescending(x => x.Grade).Take(3);
        Console.WriteLine("Best 3 students");
        foreach(var student in Sort)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
        }

7. Skip + Take + Select
Дан список чисел { 1..20 }. Пропусти первые 5, возьми следующие 5, и с помощью Select возведи их в квадрат.
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var result = numbers.Skip(5).Take(5).Select(x => x * x);
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
*/
