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
        var hasAnygrade2 = students.Any(x => x.Grades.Contains(2));
        // true or false, depending on whether any student has a grade of 2
        Console.WriteLine($"\n1. Any student has a grade of 2: {hasAnygrade2}");

        var hasAbove25 = students.All(x => x.Grades.Average() > 2.5);
        // true or false, depending on whether all students have an average grade above 2.
        Console.WriteLine($"\n2. All students have average grade above 2.5: {hasAbove25}");

        var allnames = students.Select(x => x.Name).ToList();
        var eveName = allnames.Contains("Eve");
        Console.WriteLine($"\n3. Student named Eve is in the list: {eveName}");


        var stopwatch = Stopwatch.StartNew();

        var AnyOption = students.Any(x => x.Grades.Average() < 4);
        Console.WriteLine($"\n4. Practice for Any: {AnyOption}");

        stopwatch.Stop();
        Console.WriteLine($"Function Any :{stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Restart();

        var CountOption = students.Count(x => x.Grades.Average() < 4) > 0;
        Console.WriteLine($"\n5. Practice for Count: {CountOption}");

        stopwatch.Stop();
        Console.WriteLine($"Function Count :{stopwatch.Elapsed.TotalMilliseconds} ms");



    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; init; }
}
