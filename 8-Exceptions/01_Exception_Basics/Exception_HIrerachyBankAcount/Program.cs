using System;
class Program
{
    static void Main()
    {
        BankAccount User1 = new BankAccount(223, "Krustu");
        User1.Deposit(1000);
        Console.WriteLine(User1.Balance);
        Console.ReadKey();
        var withAmount = User1.Withdraw(99999);

        Console.WriteLine(withAmount);
        Console.WriteLine(User1.Balance);
    }
}

class BankAccount
{
    public int Id { get; set; }
    public string Name { get; set; }
    private decimal _amount;
    public decimal Balance => _amount;

    public BankAccount(int id, string name)
    {
        Id = id;
        Name = name;
    }



    public void Deposit(decimal amount)
    {
        try
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "canot be zero or negative");
            if (amount > 20000)
                throw new ArgumentException(nameof(amount), "Your limit is below than 20000");
            _amount += amount;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);

        }
    }
    private void OpenPogram()
    {
        Console.WriteLine("Proccessing...");
    }
    private void CloseProgram()
    {
        Console.WriteLine("Program closing...");
    }
    public decimal Withdraw(decimal amount)
    {
        try
        {
            OpenPogram();
            if (amount > 5000)
                throw new ArgumentException(nameof(amount), "not more than 5000");

            if (amount > _amount)
                throw new InvalidOperationException(nameof(amount));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "cannot be negative");



            _amount -= amount;
            var result = amount;
            return result;

        }

        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
        finally
        {
            CloseProgram();
        }
    }
}
