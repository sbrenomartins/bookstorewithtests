
namespace Api;

public class BookService : IBookService
{
    private readonly List<Book> _books;

    public BookService()
    {
        _books = new List<Book>()
        {
            new Book()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Title="Gerenciando você mesmo",
                Author= "Peter Ducker",
            },
            new Book()
            {
                Id= new Guid("117366b8-3541-4ac5-8732-860d698e26a2"),
                Title="Evolutionary Psychology",
                Author= "David Buss",
            },
            new Book()
            {
                Id= new Guid("66ff5116-bcaa-4061-85b2-6f58fbb6db25"),
                Title="Clean Architecture",
                Author= "Uncle Bob"
            },
            new Book()
            {
                Id =  new Guid("cd5089dd-9754-4ed2-b44c-488f533243ef"),
                Title = "Domain Driven Design",
                Author = "Vaugh Vernon"
            },
            new Book()
            {
                Id =  new Guid("d81e0829-55fa-4c37-b62f-f578c692af78"),
                Title = "Unit Test - TDD",
                Author = "Will & Ariel Durant"
            }
        };
    }

    public Book Add(Book book)
    {
        book.Id = new Guid();
        _books.Add(book);
        return book;
    }

    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    public Book GetById(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        return book;
    }

    public Book Remove(Guid id)
    {
        var book = _books.First(b => b.Id == id);
        _books.Remove(book);
        return book;
    }
}
