using System;
using System.Diagnostics;
class Program
{
    // The code below demonstrates the difference in performance
    // between using Count and Any methods in C#
    // when checking for the existence of an element in a large collection.
    // The Count method iterates through the entire collection to count the occurrences,
    // while the Any method stops as soon as it finds a match,
    // making it more efficient for this use case.

    /*Итоговый вывод по всей теме
      Когда элемент есть и находится рано → Any реально быстрее Count (алгоритмическая разница, ранний выход)
      Когда элемента нет вообще → Any и Count работают одинаково (оба обязаны пройти всё) —  
      разница, которую ты увидел изначально, была не про алгоритм, а про "кто вызван первым"*/
    static void Main()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 1_000_000; i++)
        {
            numbers.Add(i);
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool hasSmallEven2 = numbers.Count(n => n == -4) > 0; // тот же логический результат
        //Count
        Console.WriteLine(hasSmallEven2);
        Console.WriteLine($"(Count)Time taken: {stopwatch.ElapsedTicks} ms");
        stopwatch.Stop();
        stopwatch.Restart();
        bool hasSmallEven = numbers.Any(n => n == -4); // совпадение почти в самом начале
        //Any
        Console.WriteLine(hasSmallEven);
        Console.WriteLine($"(Any)Time taken: {stopwatch.ElapsedTicks} ms");


        stopwatch.Stop();
    }
}
class Student
{
    public required string Name { get; set; }
    public required List<int> Grades { get; set; }
}