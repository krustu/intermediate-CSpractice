using System;
using System.Collections.Generic;
class Program
{
    

    static void Main(string[] args)
    {
        public List<User> Users = new List<User>
        {
            new User { Login = "user1", Password = "11111111" },
            new User { Login = "user2", Password = "11111111" },
            new User { Login = "user3", Password = "11111111" }
        };




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
                    // Log in logic here
                    break;
                case "2":
                    User user = new User();
                    RegisterAccount();
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
    public static void Menu()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. Settings");
            Console.WriteLine("3. Your List of Numbers");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice: ");
            string choice = INput();
            switch (choice)
            {
                case "1":
                    
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
        Console.WriteLine("all added numbers are: "); // fucntion of delete
      






        

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
            if (Users.Any(user => user.Login == login))
            {
                Console.WriteLine("Name is already taken please write again!");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("Enter new Password: ");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("Enter new Password: ");
            string age = Console.ReadLine() ?? "";

            Users.Add(new User(nameA, password, age));

            
        Console.WriteLine("Account registered successfully!");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            break;
        }
       
    }
    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("Enter your login: ");
       
            Console.WriteLine("Invalid login or password. Press any key to return to the menu.");
            Console.ReadKey();
        
    }



    public static void Info()
    {

    }
}