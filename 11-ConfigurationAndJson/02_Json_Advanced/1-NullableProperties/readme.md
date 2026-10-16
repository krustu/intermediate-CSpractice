public class User
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

## The Main Idea  
a Some proporties that might be null we use syntax ?? 
to avoid problem or rewrite varibale into new one

- int — cannot store null.

- int? — can store an integer or null.

- string? — indicates that a string can be null when nullable reference types are enabled.

# In Conclusion
Nullable properties are useful when working with JSON because API responses may contain missing or null fields,
and nullable types let us represent those values without assuming that every property has data.