using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    
    static List<User> Users = new List<User>
    {
        new User("user1", "11111111", 18),
        new User("user2", "11111111", 18),
        new User("user3", "11111111", 18)
    };
    static User currentUser;

    static void Main(string[] args)
    {
        EnterMenu();
        //  Menu();
    }
    public static void EnterMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = INput();
            switch (choice)
            {
                case "1":
                    if (TryLogin())
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Too many failed attempts. Returning to the main menu.");
                    }
                    // Log in logic here
                    break;
                case "2":
                    User.RegisterAccount(Users);
                    break;
                case "3":
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static bool TryLogin()
    {
        int attempts = 0;
        while (attempts < 5)
        {
            Console.Clear();
            Console.WriteLine("Enter your login: ");

            string login = Console.ReadLine() ?? "";
            Console.WriteLine($"login: {login}");
            Console.WriteLine("Enter your password: ");

            string password = Console.ReadLine() ?? "";
            User found = Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (found != null)
            {
                currentUser = found;
                Console.WriteLine("Login successful!");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                return true;
            }
            else
            {
                attempts++;
                Console.Clear();
                Console.WriteLine($"Invalid login or password. You have {5 - attempts} attempts left.");
                if (attempts < 5)
                {
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }
        Console.Clear();
        Console.WriteLine("Too many failed attempts. Returning to the main menu.");
        Console.ReadKey();
        return false;
    }
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. Settings");
            Console.WriteLine("3. ");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = INput();
            switch (choice)
            {
                case "1":
                    currentUser.Info();
                    break;
                case "2":
                    break;
                case "3":
                    showNames();
                    break;
                case "4":
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void showNames()
    {
        Console.Clear();
        Console.WriteLine(" "); // fucntion of delete
        Console.WriteLine("click to return to the menu");
        Console.ReadKey();
    }
    public static string INput()
    {
        while (true)
        {
            Console.Write("");
            string? choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
        }
    }
}

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }

    public User(string login, string password, int age)
    {
        Login = login;
        Password = password;
        Age = age;
    }

    public static void RegisterAccount(List<User> Users)
    {
        //user count
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Enter your login: ");
            string nameA = Console.ReadLine() ?? "";
            if (Users.Any(user => user.Login == nameA))
            {
                Console.WriteLine("Name is already taken please write again!");
                Console.ReadKey();
                continue;
            }
            Console.WriteLine($"login: {nameA}");
            Console.WriteLine("Enter new Password: ");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("Enter your age: ");
            string ageInput = Console.ReadLine() ?? "0";
            int age = int.TryParse(ageInput, out int parsedAge) ? parsedAge : 0;

            Users.Add(new User(nameA, password, age));

            Console.WriteLine("Account registered successfully!");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            break;
        }
    }
   

    public void Info()
    {
        Console.WriteLine("User Profile Information:");
        Console.WriteLine($"Login: {Login}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Password: {Password}");
        Console.ReadKey();
    }
}