using System;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;
class level4
{
    public static List<Character> Characters = new List<Character>();
    static void Main()
    {
        

    Goblin g1 = new Goblin("Хуками", 30, 5);
    Org o1 = new Org("Гром", 50, 10);
    Human h1 = new Human("Джонсон", 40, 8);

    Characters.Add(g1);
    Characters.Add(o1);
    Characters.Add(h1);
    
    g1.Attack(h1);

    Console.ReadKey();

    h1.Info();
    }
}

interface ILootable
{
    void GetLoot();
}
interface IDamageable
{
    string? Name{get; }
    void TakeDamage(int amount);
}

class Character : IDamageable
{
    public string? Name{get; set;}
    public int HP{get; set;}
    public int Dmg{get; set;}
    public bool IsAlive => HP > 0;
    public Character(string name , int hp , int dmg)
    {
        Name = name;
        HP = hp;
        Dmg = dmg;
    }
    public virtual void Info()
    {
        Console.WriteLine($"name :{Name}");
        Console.WriteLine($"HP - {HP}");
        Console.WriteLine($"basic :{Dmg} dmg");
    }

    public virtual void TakeDamage(int damage)
    {

        HP -= damage;
    }
    public virtual void Attack(IDamageable target/*each class that has proporties IDamageable */)
    {
        Console.WriteLine($"{Name} attaacks {target.Name}!");
        target.TakeDamage(Dmg);
        
    }

}
class Goblin : Character , ILootable
{
    public Goblin(string name , int hp , int dmg ) : base(name,hp,dmg)
    {
    }
     public void Loot()
        {
            Console.WriteLine($"{Name} dropped : 2-Golds , dry org's clothes");
        }
    public void GetLoot()
{
    
    if (IsAlive)
    {
        throw new Exception($"{Name} is still alive, cannot loot");
    }
    Loot();
}
}

class Org : Character , ILootable
{
   public Org(string name , int hp , int dmg ) : base(name,hp,dmg)
    {
    }
    public void Loot()
        {
            Console.WriteLine($"{Name} dropped : 2-Golds , dry org's clothes");
        }
    public void GetLoot()
{
    bool IsAlive = true;
    if (IsAlive)
    {
        throw new Exception($"{Name} is still alive, cannot loot");
    }
    Loot();
}
}

class Human : Character
{
    public Human(string name , int hp , int dmg ) : base(name,hp,dmg)
    {
    }
}
