using System;
class First
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


        var GreatStudents = students.Where(x => x.Grade >= 60).Select(students => students.Name).First();
        Console.WriteLine(GreatStudents);


    }
}
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; } // оценка от 0 до 100
}



/*1. Разминка
Дан список { 5, 12, 8, 130, 44 }. Найди первое число, которое больше 20.
List<int> numbers = new List<int> { 5, 12, 8, 130, 44 };

        var num = numbers.First(x => x > 20);
        Console.WriteLine(num);
Inptut: 130

2. Проверка на отсутствие
Дан тот же список. Попробуй найти первое число, которое больше 1000, используя FirstOrDefault. Выведи результат — что там окажется?
List<int> numbers = new List<int> { 5, 12, 8, 130, 44 };

        var num = numbers.FirstOrDefault(x => x > 150);
        Console.WriteLine(num);
Input: 0

3. Исключение
Сделай то же самое (число > 1000), но через First. Оберни вызов в try-catch и выведи сообщение об ошибке в catch.
 try
        {
            List<int> numbers = new List<int> { 5, 12, 8, 130, 44 };

            var num = numbers.First(x => x > 150);
            Console.WriteLine(num);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
Input: Sequence contains no matching element

4. Работа с объектами
Используя список Student (Name, Grade) из прошлых заданий, найди первого студента с Grade >= 90. Выведи его имя.
class First
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



        var s = students.First(x => x.Grade >= 90);

        Console.WriteLine(s.Name);

    }
}
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; } // оценка от 0 до 100
}
Input: Eban

5. FirstOrDefault с проверкой на null
Найди первого студента с Grade < 30 через FirstOrDefault. Если такой есть — выведи его имя, если нет — выведи "Отличников без проблем нет".
ar s = students.FirstOrDefault(x => x.Grade < 30);

        if (s != null)
        {
            Console.WriteLine(s.Name);
        }
        else
        {
            Console.WriteLine("there are no students with a grade below 30");
        }
Input: Kser

6. First + строки
Дан список слов { "кот", "собака", "слон", "жираф" }. Найди первое слово, длина которого больше 4 символов.
List<string > animal = new List<string> { "cat", "dog", "elephant", "giraffe" };
        var word4 = animal.First(x => x.Length > 4);
        Console.WriteLine(word4);
Input: elephant

7. Комбинация с Select
Дан список Student. С помощью Where + Select получи список имён студентов с Grade >= 60, а затем через First возьми первое имя из этого списка.
 var GreatStudents = students.Where(x => x.Grade >= 60).Select(students => students.Name).First();
        Console.WriteLine(GreatStudents);
Input: Krustu
*/