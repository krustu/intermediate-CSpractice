using System;
using System.ComponentModel;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {

        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Grades = new List<int> { 5, 4, 5 } },
            new Student { Name = "Bob", Grades = new List<int> { 3, 4, 2 } },
            new Student { Name = "Charlie", Grades = new List<int> { 5, 5, 5, 4 } },
            new Student { Name = "Diana", Grades = new List<int> { 4, 4, 3 } }
        };

        var highAvarageScore = students.Where(x => x.Grades.Average() > 4);
        // task 1 
        Console.WriteLine("List of students with avarage score greater than 4:");
        foreach (var student in highAvarageScore)
        {
            Console.WriteLine($"{student.Name}: {student.Grades.Average():F2}");
        }

        Console.WriteLine("\nList of students:");
        var allnames = students.Select(x => x.Name);
        foreach (var name in allnames)
        {
            Console.WriteLine(name);
        }
        ;

        Console.WriteLine("\nList Grades");
        var AllGrades = students.SelectMany(x => x.Grades);

        foreach (var grade in AllGrades)
        {
            Console.WriteLine(grade);
        }

        Console.WriteLine("\n(using where and select) List of students with avarage score greater than 4:");
        var highAvarageScore2 = students.Where(x => x.Grades.Average() > 4).Select(x => x.Name);

        foreach (var name in highAvarageScore2)
        {
            Console.WriteLine(name);
        }

    }

    public class Student
    {
        public required string Name { get; init; }
        public required List<int> Grades { get; init; } // оценки по разным предметам
    }
}

