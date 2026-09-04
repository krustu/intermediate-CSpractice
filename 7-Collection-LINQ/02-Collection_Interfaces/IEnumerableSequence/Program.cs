class Program
{
    static void Main(string[] args)
    {

        foreach (var num in EvenNumbersUpTo(10))
        {
            Console.WriteLine($"Taken: {num}");
            if (num == 10) break;
        }
    }
    public static IEnumerable<int> EvenNumbersUpTo(int max)
    {
        for (int a = 0; a < max; a += 1)
        {
            Console.WriteLine($"Generated: {a}");
            yield return a;

        }
    }


}
