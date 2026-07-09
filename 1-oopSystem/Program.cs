using System;
using System.Collections.Generic;
class AnimalShelter
{
    static List<Animal> animals = new List<Animal>(); // another name is Feedables
    static List<IFeedable> feedables = new List<IFeedable>();
    
    static void Main()
    {
         Dog g1 = new Dog( "Buddy", 3 , "Bulldog" );
         Dog g2 = new Dog( "Max", 5 , "Golden Retriever" );
         Cat c1 = new Cat( "Fluffy", 2 , "Orange" );
         Cat c2 = new Cat( "Whiskers", 4 , "Black" );
         Cat c3 = new Cat("Mittens", 1, "White");
         animals.Add(g1);
         feedables.Add(g1);
         animals.Add(g2);
         feedables.Add(g2);
         animals.Add(c1);
         feedables.Add(c1);
         animals.Add(c2);
         feedables.Add(c2);
         animals.Add(c3);
         feedables.Add(c3);
         foreach (Animal animal in animals)
         {
            animal.Info();
         }
        

         Console.ReadKey();
        foreach (IFeedable f in feedables)
        {
            f.Feed();
        }

      /*List<IFeedable> feedables = new List<IFeedable>();
foreach (IFeedable f in feedables) { f.Feed(); }*/
    }
}
interface IFeedable
{
    void Feed();
}
class Animal //: IFeedable
{
    public string? Name { get; set; }
    public int Age { get; set; }
    
    public Animal(string name , int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Info()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

}
class Dog : Animal , IFeedable
{
  
  public void Feed()
    {
        Console.WriteLine($"{Name} is eated sasiska.");
    }
   public string Breed {get; set;}
   public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }
    

    public override void Info()
    {
        Console.WriteLine("This is a dog.");
        base.Info();
    }
}
class Cat : Animal , IFeedable
{
    public void Feed()
    {
        Console.WriteLine($"{Name} is eated fish.");
    }
 public string? Color { get; set; }
   public Cat(string name, int age, string color) : base(name, age)
    {
        Color = color;
    }
    public override void Info()
    {
        Console.WriteLine("This is a cat.");
        base.Info();
    }
}
