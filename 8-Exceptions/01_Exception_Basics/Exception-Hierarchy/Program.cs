using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main()
    {
        ProcessValue(null);

        // 1) With using "Null" - Catch ArgumentNullException: Value can not be null (Parameter 'value')
        // 2) With using "0" - Catch DivideByZeroException: Attempted to divide by zero.
        // 3) With using "5" - Result: 20
    }
    static void ProcessValue(int? value)
    {
        try
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Value can not be null");

            int result = 100 / value.Value;
            Console.WriteLine($"Result: {result}");
        }

        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Catch ArgumentNullException: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Catch DivideByZeroException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Catch something other: {ex.Message}");
        }
    }
}
