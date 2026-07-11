using System;
using System.Collections.Specialized;
class Level3
{
   // static List<IUse> Usable = new List<IUse>();
    
    static void Main()
    {
        List<IUse> Weapons = new List<IUse>();

    try
{
    Console.WriteLine("Введите имя меча:");
    string? name = Console.ReadLine() ?? "";
    /*if (name != null)
            {
                Sword s1 = new Sword(name);
                Weapons.Add(s1);
            }*/
    Sword s1 = new Sword(name);
                Weapons.Add(s1);
    
    Console.WriteLine("Успешно добавлено");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}



        
        /* 
            Console.WriteLine("Create the item");
            Console.ReadKey();
            
            Console.WriteLine("Sword - 1");
            Console.WriteLine("Bow   - 2");
            Console.WriteLine("Staff - 3");
            Console.WriteLine("Choose the option");
            string choice = INput();
            switch (choice)
        {
            case "1":
              
            break;

            case "2":

            break;

            case "3":

            break;
                        
        }




          string ?a = Console.ReadLine();
            string ?b = Console.ReadLine();
            


            Sword s1 = new Sword
            {
                Name = a,
                Type = b,
            };
           */


         
    }
        
        public static string INput()
        {
            while (true)
            {
                Console.Write("");
                string ?choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" )
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please write only 1,2,3.");
                   
                }
            }
        }
        
    }



interface IUse
{
    void Use();
}
class Item : IUse
{
    public string Name{get; set;}
   /* public string ?Type{get; set;}
    public virtual int Damage{get; private set;} = 10;
    public virtual void Upgrade()
    {
        Damage += 5;
    } */

    public Item(string name /*string type , int damage*/)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Name can not be empty");
        }
        Name = name;
    }
    public virtual void Use()
    {
        Console.WriteLine("Item action");
    }
    public virtual void Info()
    {
        Console.WriteLine($"Name: {Name}");
       // Console.WriteLine($"Type: {Type}");
       // Console.WriteLine($"Damage {Damage}"); 
    }
}
class Sword : Item 
{
    public Sword(string name /*string type , int damage*/) : base(name)
    {
        Name = name;
    }
    public override void Use()
    {
        Console.WriteLine("swings the sword");
    }
}
class Bow : Item 
{
    public Bow(string name /*string type , int damage*/) : base(name)
    {
        Name = name;
    }
    public override void Use()
    {
        Console.WriteLine("shoots an arrow");
    }
}
class Staff : Item
{
    public Staff(string name /*string type , int damage*/) : base(name)
    {
        Name = name;
    }
    public override void Use()
    {
        Console.WriteLine("casts a spell");
    }
}