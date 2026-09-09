using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        List<string> names = new List<string>
{
    "Alice", "Bob", "Charlie", "Diana", "Eve", "Frank", "Grace", "Henry", "Ivy", "Jack"
};
        // 1Collection 2 Page 3 Size   
        var page1 = GetPage(names, 2, 5);
        foreach (var name in page1)
        {
            Console.WriteLine(name);
        }


    }
    static List<string> GetPage(List<string> Items, int PageNum, int PageSize)
    {
        return Items.Skip((PageNum - 1) * PageSize).Take(PageSize).ToList();
    }
}


