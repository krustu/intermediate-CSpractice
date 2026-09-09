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
    new Student { Name = "Charlie", Grades = new List<int> { 5, 5, 5, 4} },
    new Student { Name = "Diana", Grades = new List<int> { 4, 4, 3 , 3} }
};
        // Amount of all Grades task1
        var avarageGrades = students.Sum(x => x.Grades.Sum());
        Console.WriteLine($"Average Grades: {avarageGrades:F2}");

        //task2
        double mostLow = students.Min(x => x.Grades.Average());
        double mostHigh = students.Max(x => x.Grades.Average());
        Console.WriteLine($"Most Low Grade: {mostLow:F2}");
        Console.WriteLine($"Most High Grade: {mostHigh:F2}");

        //task3
        var HighGradeStudent = students.MaxBy(x => x.Grades.Average());
        Console.WriteLine($"Student: {HighGradeStudent.Name} with an average of {HighGradeStudent.Grades.Average():F2}");


        /*"" — это начальное значение аккумулятора (seed). 
         * Ты верно понял, что это "чтобы получить строку" — но конкретнее: 
         * это стартовая точка, с чего аккумулятор начинает до обработки первого элемента. 
         * Без seed (Aggregate((acc, n) => ...) без первого аргумента) 
         * Aggregate взял бы первый элемент коллекции как стартовое значение аккумулятора — 
         * но тогда тип аккумулятора должен был бы совпадать с типом элементов (Student, не string), 
         * что не подошло бы для построения строки. 
         * Поэтому именно явный seed = "" обязателен здесь — он позволяет типу аккумулятора быть string, 
         * отдельно от типа элементов (Student).*/
        //Task4
        string result = students.Aggregate("", (acc, n) => acc + n.Name + ",");
        Console.WriteLine($"Students: {result.TrimEnd(',')}");

        var result2 = students.Aggregate("", (acc, n) =>
        acc == "" ? n.Name : acc + ", " + n.Name
        );
        Console.WriteLine(result2);
    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; set; }
}
