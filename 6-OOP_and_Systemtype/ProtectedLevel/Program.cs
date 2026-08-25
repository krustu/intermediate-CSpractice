using System;
class Program
{
    static void Main()
    {

        Manager managaer = new Manager(25530m, "Rysbek");
        managaer.GetInfo();
        managaer.AwardBonus();
        managaer.GetInfo();
      //  managaer.CalculateBonus(); we cannot use method from main class now is protected for safety. we can only work with inherited class -Manger
    }
}
public class Employee
{
    private string Name { get; set; }
    private decimal _salary;
    public decimal Salary
    {
        get
        {
            return _salary;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Cannot be negative");
            if (value > 1_000_000)
                throw new ArgumentException("Salary is too high");
            _salary = value;
        }
    }
    public Employee(decimal salary, string name)
    {
        Salary = salary;
        Name = name;
    }
    protected decimal CalculateBonus()
    {

        return Salary * 0.1m;


    }
    public void GetInfo()
    {
        Console.WriteLine($"Name- {Name} Salary-{Salary} Usd");
    }

}

public class Manager : Employee
{
    public Manager(decimal salary, string name) : base(salary, name) { }
    public void AwardBonus()
    {

        var result = CalculateBonus();

        Console.WriteLine($"Bonus - {result} Usd");
    }

}


