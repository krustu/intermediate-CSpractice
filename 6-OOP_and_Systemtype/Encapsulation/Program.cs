using System;
class Program
{
    static void Main()
    {
        try
        {
            Person person = new Person(0, "");

            Console.WriteLine($"Name - {person.Name} Age - {person.Age}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.ReadKey();

    }
}
public class Person
{
    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Bro write your age correctly!");
            }
            _age = value;
        }
    }
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new ArgumentException("Write Your Name!");
            }
            else
            {
                _name = value;
            }

        }
    }
    public Person(int age, string name)
    {
        Age = age;
        Name = name;
    }
}


