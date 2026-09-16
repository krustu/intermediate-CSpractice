using System;
class Program
{
    static void Main()
    {
        BankAccount User1 = new BankAccount(223, "Krustu");
        User1.Deposit(2000);
        //99999 = You exceeded the deposit limit
        //-99 = You entered an invalid amount

        Console.WriteLine(User1.Balance);
        Console.ReadKey();
        try
        {
            var withAmount = User1.Withdraw(20000);
            Console.WriteLine(withAmount);
            Console.WriteLine(User1.Balance);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }



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
                throw new ArgumentException("Amount must be Positive", nameof(amount));
            if (amount > 20000)
                throw new ArgumentException("deposit Limit Exceeded", nameof(amount));
            if (amount == 13)
                throw new ArgumentException("Unlucky number", nameof(amount));
            _amount += amount;
        }
        catch (ArgumentException) when (amount <= 0)
        {
            Console.WriteLine("You entered an invalid amount");

        }
        catch (ArgumentException) when (amount > 20000)
        {
            Console.WriteLine("You exceeded the deposit limit");

        }
        catch (ArgumentException ex) // без when — ловит ВСЁ остальное этого типа
        {
            Console.WriteLine($"Another problems: {ex.Message}");
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
    public bool TryWithdraw(decimal amount, out string errorMessage)
    {
        errorMessage = "";
        if (amount > 5000)
        {
            errorMessage = "You have reached youy limit";
            return false;
        }

        if (amount > _amount)
        {
            errorMessage = "You do not have enough money";
            return false;
        }

        if (amount < 0)
        {
            errorMessage = "Your amount is zero";
            return false;
        }
        _amount -= amount;
        return true;

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
            throw;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        finally
        {
            CloseProgram();
        }
    }
}
