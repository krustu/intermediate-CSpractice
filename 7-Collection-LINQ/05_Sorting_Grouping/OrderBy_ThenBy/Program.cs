using System;
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
{
         new Student { Name = "Bob", Grades = new List<int> { 4, 4, 3 } },      // средний ~3.67
         new Student { Name = "Alice", Grades = new List<int> { 5, 4, 5 } },    // средний ~4.67
         new Student { Name = "Diana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Ciana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Iiana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Xiana", Grades = new List<int> { 5, 4, 5 } },// тоже средний ~4.67 — совпадает с Alice!
         new Student { Name = "Charlie", Grades = new List<int> { 5, 5, 5, 4 } } // средний 4.75
};


        var student = students.OrderByDescending(x => x.Grades
                              .Average())
                              .ThenBy(x => x.Name)
                              .ToList();

        foreach (var a in student)
        {
            Console.WriteLine($"{a.Name}: {a.Grades.Average():F2}");
        }

        try
        {
            Console.WriteLine("--------------------------------------------------");
            var student2 = students.OrderBy(x => x.Grades.Average()).OrderBy(x => x.Name).ToList();
            foreach (var a in student2)
            {
                Console.WriteLine($"{a.Name}: {a.Grades.Average():F2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; set; }
}
