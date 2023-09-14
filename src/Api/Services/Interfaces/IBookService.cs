namespace Api;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book GetById(Guid id);
    Book Add(Book book);
    Book Remove(Guid id);
}
