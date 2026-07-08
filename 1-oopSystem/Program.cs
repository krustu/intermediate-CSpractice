using System;
using System.Collections.Generic;
class AnimalShelter
{
    static List<Animal> animals = new List<Animal>();
    static void Main()
    {
         Animal g1 = new Dog( "Buddy", 3 , "Bulldog" );
         animals.Add(g1);
         Animal g2 = new Dog( "Max", 5 , "Golden Retriever" );
         animals.Add(g2);
         Animal c1 = new Cat( "Fluffy", 2 , "Orange" );
         Animal c2 = new Cat( "Whiskers", 4 , "Black" );
         animals.Add(c1);
         animals.Add(c2);
         Animal c3 = new Cat("Mittens", 1, "White");
         animals.Add(c3);
         foreach (Animal animal in animals)
         {
            animal.Info();
         }

      
    }
}
class Animal
{
    
    public string? Name { get; set; }
    public int Age { get; set; }
    public Animal(string name , int age)
    {
        Name = name;
        Age = age;
    }
    public Animal()
    {

    }

    public virtual void Info()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

}
class Dog : Animal
{
   string breed {get; set;}
   public Dog(string name, int age, string Breed) : base(name, age)
    {
        breed = Breed;
    }
    

    public override void Info()
    {
        Console.WriteLine("This is a dog.");
        base.Info();
    }
}
class Cat : Animal
{
    public string? color { get; set; }
   public Cat()
    {
    }
   public Cat(string name, int age, string Color) : base(name, age)
    {
        color = Color;
    }
    public override void Info()
    {
        Console.WriteLine("This is a cat.");
        base.Info();
    }
}
