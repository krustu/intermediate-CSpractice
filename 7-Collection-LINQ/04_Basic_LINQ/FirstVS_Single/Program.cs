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
         new Student { Name = "Bob", Grades = new List<int> { 4, 4, 3 } }

};
        //Funtion First - find bob in the list of students and print his name
        var bobic = students.First(x => x.Name == "Bob");
        Console.WriteLine(bobic.Name);

        //Function FirstOrDefault - find eve in the list of students and print her name, if not found print "Eve not found"
        var EveElfi = students.FirstOrDefault(x => x.Name == "Eve");
        if (EveElfi == null)
        {
            Console.WriteLine("Eve not found");
        }
        else
        {
            Console.WriteLine(EveElfi.Name);
        }

        try
        {
            var SingleBob = students.Single(x => x.Name == "Boba"); // Alice // Bob
            Console.WriteLine(SingleBob.Name);

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