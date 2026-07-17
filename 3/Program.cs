using System;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;
class level4
{
    public static List<Character> Characters = new List<Character>();
    static void Main()
    {
        

    }
}

interface ILootable
{
    void Loot();
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
    public Character(string name , int hp , int dmg)
    {
        Name = name;
        HP = hp;
        Dmg = dmg;
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
        Console.WriteLine("Looted 2-Gold");
    }
}
class Org : Character , ILootable
{
   public Org(string name , int hp , int dmg ) : base(name,hp,dmg)
    {
    }
    public void Loot()
    {
        Console.WriteLine("Looted dry org's clothes");
    }
}
class Human : Character
{
    public Human(string name , int hp , int dmg ) : base(name,hp,dmg)
    {
    }
}