using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return Title;
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // 1. IEnumerable<T>
    public IEnumerable<Book> GetBooks()
    {
        return books;
    }

    // 2. ICollection<T>
    public ICollection<Book> GetBookCollection()
    {
        return books;
    }

    // 3. IList<T>
    public IList<Book> GetBookList()
    {
        return books;
    }

    // 4. IReadOnlyList<T>
    public IReadOnlyList<Book> GetReadOnlyBooks()
    {
        return books;
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book("Harry Potter"));
        library.AddBook(new Book("The Hobbit"));
        library.AddBook(new Book("1984"));
    }
}
