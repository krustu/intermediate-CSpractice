using System;
class Program
{
    static void Main(string[] args)
    {
        var Num = DataNames.GetDataNames.Count();
        FileProcessor processor = new FileProcessor();
        processor.Open();
        for (int a = 0; a < Num; a++)
        {
            processor.ReadByNum(DataNames.GetDataNames, a);
        }

    }
}
public class People
{
    public required int Id { get; set; }
    public string? Name { get; set; }
}
class FileProcessor
{
    public void Open()
    {
        Console.WriteLine("Program Opening..");
    }
    public string ReadByNum(List<People> list, int index)
    {
        try
        {
            People person = list[index];

            if (person.Name == null)
            {
                throw new ArgumentNullException(nameof(person.Name));
            }
            else if (person.Name == "")
                throw new ArgumentException(
                    "PErson name cannot be empty", nameof(person.Name));

            Console.WriteLine($"{person.Name} was added successfuly");
            return person.Name;


        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            return "no name";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"{ex.Message}");
            return "Empty name";
        }
        finally
        {

            Console.WriteLine("Program Closing...");
        }
    }
}
public static class DataNames
{
    public static List<People> GetDataNames { get; } = new List<People> {
        new People {Id = 1 , Name = null},
        new People {Id = 2 , Name = "KRustu"},
        new People {Id = 3 , Name = "John"},
        new People {Id = 4 , Name = null},
        new People {Id = 5 , Name = "Salovey"},
        new People {Id = 6 , Name = "Indian"},
        new People {Id = 7 , Name = "Robot22"},
        new People {Id = 8 , Name = ""},
    };
}