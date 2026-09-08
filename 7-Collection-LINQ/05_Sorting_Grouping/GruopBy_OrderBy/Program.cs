using System;
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
{
         new Student { Name = "Bob", Grades = new List<int> { 4, 4, 3 } },      // средний ~3.67
         new Student { Name = "Alice", Grades = new List<int> { 5, 4, 5 } },    // средний ~4.67
         new Student { Name = "Diana", Grades = new List<int> { 3, 4, 5 } },
         new Student { Name = "Ciana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Iiana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Xiana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Bober", Grades = new List<int> { 2, 4, 3 } },      // средний ~3.67
         new Student { Name = "Alye", Grades = new List<int> { 5, 3, 2 } },    // средний ~4.67
         new Student { Name = "Dayana", Grades = new List<int> { 1, 1, 3 } },
         new Student { Name = "Cireana", Grades = new List<int> { 5, 4, 4 } },
         new Student { Name = "Loxik", Grades = new List<int> { 1, 4, 5 } },
         new Student { Name = "Xysan", Grades = new List<int> { 5, 2, 5 } },// тоже средний ~4.67 — совпадает с Alice!
         new Student { Name = "bonny", Grades = new List<int> { 5, 5, 5 } } // средний 4.75
};
        Console.WriteLine("Task 1: Group students by the first letter of their names and display their average grades.");
        var studentsName = students.GroupBy(x => x.Name[0]);
        foreach (var group in studentsName)
        {
            Console.WriteLine($"Names starting with '{group.Key}':");
            foreach (var student in group)
            {
                Console.WriteLine($"  {student.Name}: {student.Grades.Average():F2}");
            }
        }

        Console.WriteLine("\nTask 2: Group students by their average grades and display the groups in order of performance.");
        var GroupedByMarks = students.GroupBy(x =>
        {
            double average = x.Grades.Average();
            if (average >= 4.5)
                return "Excellent";
            else if (average >= 3.5)
                return "Good";
            else if (average >= 2.5)
                return "Average";
            else
                return "Poor";
        }).OrderBy(x =>
        {
            return x.Key switch
            {
                "Excellent" => 1,
                "Good" => 2,
                "Average" => 3,
                "Poor" => 4,
                _ => 5
            };

        }).ToList();

        Console.WriteLine("\nStudents grouped by their average grades:");
        foreach (var group in GroupedByMarks)
        {
            Console.WriteLine($" current - {group.Key}:");
            foreach (var student in group)
            {
                Console.WriteLine($"  {student.Name} {student.Grades.Average():F2}");
            }
        }

        Console.WriteLine("\nTask 3: Display the top Groups with highest number of students");

        var topGruop = GroupedByMarks.OrderByDescending(g => g.Count()).First();
        Console.WriteLine($"\nTop Group: {topGruop.Key} with {topGruop.Count()} students");
        foreach (var student in topGruop)
        {
            Console.WriteLine($"  {student.Name} {student.Grades.Average():F2}");
        }
    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; set; }
}