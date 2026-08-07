using System;
class Where
{
    static void Main()
    {
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

       var result = students.Where(x => x.Grade > 1000).ToList();
        Console.WriteLine(result.Count());
    }
}
class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}
/*Задания на Where

1. Разминка
Дан список { 5, 12, 8, 130, 44, 3, 99 }. Получи только числа больше 20.
List<int> ints = new List<int> { 5, 12, 8, 130, 44, 3, 99 };
        var result = ints.Where(x => x > 20).ToList();
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
Input: 5, 12, 8, 130, 44, 3, 99

2. Чётные/нечётные
Тот же список. Получи только чётные числа.
List<int> ints = new List<int> { 5, 12, 8, 130, 44, 3, 99 };
        var result = ints.Where(x => x % 2 == 0).ToList();
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
Input: 12 , 8, 130, 44

3. Строки по длине
Дан список слов { "кот", "собака", "слон", "жираф", "уж" }. Получи только слова длиннее 3 символов.
List<string> strings = new List<string> { "Cat", "Dog", "Elephant", "Jiraf", "Uj" };
        var result = strings.Where(x => x.Length > 3).ToList();
        foreach(var a in result)
        {
            Console.WriteLine(a);
        }
Input: "Elephant", "Jiraf"

4. Объекты + фильтр
Используя список Student, получи только тех, кто не сдал (Grade < 60).
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

        var result = students.Where(x => x.Grade < 60).ToList();
        foreach ( var student in result)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
        }
Input:
Name: Kser, Grade: 25
Name: Hyesos, Grade: 15
Name: Naagibator, Grade: 2
Name: Kse223fr, Grade: 25
Name: Lox, Grade: 9
Name: ibator, Grade: 40


5. Два условия
Используя тот же список, получи студентов с Grade от 60 до 90 (включительно) — то есть сдали, но не отличники.
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

        var result = students.Where(x => x.Grade > 60 && x.Grade <= 90).ToList();
        foreach ( var student in result)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
        }
Input: Name: Krustu, Grade: 85 Name: Eban, Grade: 90

6. Where + Select
Дан список Student. Сначала отфильтруй тех, у кого Grade >= 75, а затем через Select получи только их имена.
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

        var result = students.Where(x => x.Grade >= 75).Select(x => x.Name).ToList();
        foreach ( var student in result)
        {
            Console.WriteLine($"Name: {student}");
        }
Input : Name: Krustu Name: Eban Name: Lox Name: Hys

7. Where + Count
Дан список чисел { 1..30 }. Посчитай, сколько чисел делится на 3 (используй Where, а результат оберни в .Count()).
List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

        var result = list.Where(x => x % 3 == 0).Count();
        Console.WriteLine(result);
Input: 10

8. Where с индексом
Дан список { "a", "b", "c", "d", "e", "f" }. С помощью Where с индексом получи только элементы на нечётных позициях (индексы 1, 3, 5 → b, d, f).
List<string> Alp = new List<string> { "a", "b", "c", "d", "e", "f" };
        var result = Alp.Where((x, Index) => Index % 2 != 0).ToList();
        foreach(var x in result)
        {
            Console.WriteLine(x);
        }
Input: b, d, f

9. Пустой результат
Дан список Student. Попробуй отфильтровать студентов с Grade > 1000. Проверь, что вернётся — null, исключение или пустая коллекция? Выведи количество элементов результата (.Count()), чтобы убедиться.

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

       var result = students.Where(x => x.Grade > 1000).ToList();
        Console.WriteLine(result.Count());

 Input : 0*/
