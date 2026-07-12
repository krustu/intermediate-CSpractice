using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration.Assemblies;
using System.Runtime.Intrinsics.X86;
class Level3
{
   // static List<IUse> Usable = new List<IUse>();
    static List<IUse> Usable = new List<IUse>();
    static void Main()
{
      
      while(true)
      {
        
        

 
Console.WriteLine("Create the item - 1");
Console.WriteLine("Show all Items  - 2");
Console.WriteLine("Exit            - 3");

string choice1 = INput();

switch (choice1)
{
    case "1":

        Console.WriteLine("Sword - 1");
        Console.WriteLine("Bow   - 2");
        Console.WriteLine("Staff - 3");
        Console.WriteLine("get back - 4");
        Console.WriteLine("Choose the option");

        string choice = INput();

        switch (choice)
        {
            case "1":
                try
                {
                    Console.WriteLine("Name of sword:");
                    string nameSword = Console.ReadLine() ?? "";

                    Sword s1 = new Sword(nameSword);
                    Usable.Add(s1);

                    Console.WriteLine("Added successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "2":
                try
                {
                    Console.WriteLine("Name of Bow:");
                    string nameBow = Console.ReadLine() ?? "";

                    Bow b1 = new Bow(nameBow);
                    Usable.Add(b1);

                    Console.WriteLine("Added successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "3":
                try
                {
                    Console.WriteLine("Name of Staff:");
                    string nameStaff = Console.ReadLine() ?? "";

                    Staff st1 = new Staff(nameStaff);
                    Usable.Add(st1);

                    Console.WriteLine("Added successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
        }

        break;

           
            case "4":
            break;
                        
        
                case "2":
                    {
                        foreach(Item item in Usable)
        {
            Console.WriteLine("Current list: ");
            item.Info();
            Console.WriteLine("Ability :");
            item.Use();

        };
                    }
                break;

                case "3":
                return;
            }


            
          
         
    
        
    

        
    
           
    
    





  

    
         
    }
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

    }
    public override void Use()
    {
        Console.WriteLine("casts a spell");
    }
}


/*if (name != null)
            {
                Sword s1 = new Sword(name);
                Weapons.Add(s1);
            }*/


            /* try
{
    Console.WriteLine("Введите имя меча:");
    string? name = Console.ReadLine() ?? "";
   
    Sword s1 = new Sword(name);
                Weapons.Add(s1);
    
    Console.WriteLine("Added successfuly");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}*/
