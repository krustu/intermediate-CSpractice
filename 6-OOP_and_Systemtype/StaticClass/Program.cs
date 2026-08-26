using System;
using System.Runtime.CompilerServices;
class Program
{
    static void Main()
    {
        List<BankAaccount> UserBalance = new List<BankAaccount>();

        BankAaccount bank1 = new BankAaccount(613.3m, "Krustu");
        UserBalance.Add(bank1);
        BankAaccount bank2 = new BankAaccount(233.2m, "Loxie");
        UserBalance.Add(bank2);
        BankAaccount bank3 = new BankAaccount(523.23m, "John");
        UserBalance.Add(bank3);
        BankAaccount bank4 = new BankAaccount(113.03m, "Keponya");
        UserBalance.Add(bank4);
        Console.WriteLine(BankAaccount.TotalAccountsCreated);
        //usd rate 89 per 1 
        var result = BankUtils.ConvertToUSd(1000, 0.023m);

        Console.WriteLine(result);


        foreach (var account in UserBalance)
        {
            var Answer = BankUtils.ConvertToUSd(account.GetBalance(), 0.023m);
            Console.WriteLine($"user:{account.Name} Balance - {account.GetBalance()} Exchhanged - {Answer} USd");
        }
        Console.ReadKey();
    }
}
public static class BankUtils
{
    public static decimal ConvertToUSd(decimal amount, decimal EXchangeRate)
    {
        var result = amount * EXchangeRate;
        return result;
    }
}
public class BankAaccount
{

    private decimal _balance;
    public string Name { get; init; }
    public static int TotalAccountsCreated = 0;
    public BankAaccount(decimal balance, string name)
    {
        Name = name;
        _balance = balance;
        TotalAccountsCreated++;
    }
    public decimal GetBalance()
    {
        return _balance;
    }
}