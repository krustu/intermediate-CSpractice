using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
       {
         new Student { Name = "Alice", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Bob", Grades = new List<int> { 3, 4, 2 } },
         new Student { Name = "Charlie", Grades = new List<int> { 5, 5, 5, 4 } },
         new Student { Name = "Diana", Grades = new List<int> { 4, 4, 3 } }
       };


        var result = students.Where(IsHighAchiver);
        foreach (var student in result)
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("Using Lambda Expression:------------------------------------------------------------");
        var result2 = students.Where(x => x.Grades.Average() > 4.0);
        foreach (var student in result2)
        {
            Console.WriteLine(student.Name);
        }
    }
    static bool IsHighAchiver(Student student)
    {
        return student.Grades.Average() > 4.0;

    }
}

class Student
{
    public required string Name { get; init; }
    public required List<int> Grades { get; set; }


}

