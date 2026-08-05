using System;
using System.Security.Cryptography.X509Certificates;
class AnyProgram
{
    static void Main()
    {
       
        List<string> heroes = new()
{
    "Arthur",
    "Merlin",
    "Robin"
};

        List<string> monsters = new()
{
    "Goblin",
    "Orc",
    "Dragon",
    "Dragon"
};

        var allHeroes = heroes.Concat(monsters).Distinct();
        

        foreach (var hero in allHeroes)
        {
            Console.WriteLine(hero);
        }


        Console.WriteLine("Number of Characters");
        Console.WriteLine(allHeroes.Count());



    }
}
/*int[] a = { 1, 2, 3, 4, 5, 6, 7, };
        int[] b = { 8, 9, 10, 11, 12, 13, 14, 15, 1 , 2, 3, 4, 5, 6, 7, 8 };

        var result = b.Concat(a).Distinct();

        foreach (var i in result)
        {
            Console.WriteLine(i);
        }*/