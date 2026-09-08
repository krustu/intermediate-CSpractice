using System;
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
{
         new Student { Name = "Bob", Grades = new List<int> { 4, 4, 3 } },
         new Student { Name = "Alice", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Diana", Grades = new List<int> { 3, 4, 5 } },
         new Student { Name = "Ciana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Iiana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Xiana", Grades = new List<int> { 5, 4, 5 } },
         new Student { Name = "Bober", Grades = new List<int> { 2, 4, 3 } },
         new Student { Name = "Alye", Grades = new List<int> { 5, 3, 2 } },
         new Student { Name = "Dayana", Grades = new List<int> { 1, 1, 3 } },
         new Student { Name = "Cireana", Grades = new List<int> { 5, 4, 4 } },
         new Student { Name = "Loxik", Grades = new List<int> { 1, 4, 5 } },
         new Student { Name = "Xysan", Grades = new List<int> { 5, 2, 5 } },
         new Student { Name = "bonny", Grades = new List<int> { 5, 5, 5 } },
         new Student { Name = "bonny", Grades = new List<int> { 1, 1, 1 } }

};

        //task 1 just print all names of students by using ToArray()
        var Names = students.Select(x => x.Name).ToArray();
        foreach (var name in Names)
        {
            Console.WriteLine(name);
        }

        //Console.WriteLine(Names[1]);


        //task 2 print all names of students with their average grade by using ToDictionary()
        try
        {
            var Dictionary = students.GroupBy(x => x.Name)
                                     .ToDictionary(x => x.Key, x => x.Average(x => x.Grades.Average()));
            int count = 1; //combine all duplicates in one and show the average grade of all duplicates
            foreach (var a in Dictionary)
            {
                Console.WriteLine($"{count} - {a.Key}, Average Grade: {a.Value:F2}");

                count++;
            }


        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);

        }

        Console.WriteLine("--------------------------------------------------------------------------------------------");
        //task3 print all names of students with their average grade by using ToHashSet()
        var hashset = students.Select(x => x.Name).ToHashSet();
        int count2 = 1;
        foreach (var name in hashset)
        {

            Console.WriteLine($"{count2} - {name}");
            count2++;
        }
    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; set; }
}