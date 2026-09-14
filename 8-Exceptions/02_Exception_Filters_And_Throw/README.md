## Filter in Exception 
try
{
    MakeRequest();
}
catch (HttpRequestException ex) when (ex.Message.Contains("404"))
{
    Console.WriteLine("Ресурс не найден");
}
catch (HttpRequestException ex) when (ex.Message.Contains("500"))
{
    Console.WriteLine("Ошибка сервера, повторить позже");
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Другая сетевая проблема");
}

## When `when` is truly useful
 - Different reactions to specific details of the same exception type
 (specific message, specific parameter, specific error code)

 - Conditional handling based on external state 
 (e.g., "catch only if it's the third consecutive attempt")

# What I Learned

Including the current topic and the previous ones,
I learned how to catch unexpected errors and add extra conditions to `catch` blocks without using `if` statements. 
I also learned how to use `when` to specify several conditions for the same `ArgumentException`.
