using Api;
using NuGet.Frameworks;

namespace Tests;

public class BookStoreTest
{
    IBookService _service;

    public BookStoreTest()
    {
        _service = new BookService();
    }

    [Fact]
    public void GetAllBooksSuccess()
    {
        //Arrange
        //Act
        var result = _service.GetAll();

        //Assert
        Assert.IsType<List<Book>>(result);
        Assert.Equal(5, result.Count());
    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", "ab2bd817-98cd-4cf3-a80a-53ea0cd9c111")]
    public void GetBookByIdSuccessAndError(string guid1, string guid2)
    {
        // Arrange
        var validGuid = new Guid(guid1);
        var invalidGuid = new Guid(guid2);

        // Act
        var okResult = _service.GetById(validGuid);
        var nullResult = _service.GetById(invalidGuid);

        // Assert
        Assert.IsType<Book>(okResult);
        Assert.Null(nullResult);

        Assert.Equal(validGuid, okResult.Id);
        Assert.Equal("Gerenciando você mesmo", okResult.Title);
    }

    [Fact]
    public void CreateBookSuccess()
    {
        // Arrange
        var newBook = new Book
        {
            Title = "My Book",
            Author = "Breno M. Silva"
        };

        // Act
        var createdResponse = _service.Add(newBook);

        // Assert
        Assert.IsType<Book>(createdResponse);
        Assert.Equal(newBook.Author, createdResponse.Author);
        Assert.Equal(newBook.Title, createdResponse.Title);
    }

    [Theory]
    [InlineData("d81e0829-55fa-4c37-b62f-f578c692af78")]
    public void RemoveBookSuccess(string guid1)
    {
        // Arrange
        var validGuid = new Guid(guid1);

        // Act
        var okResult = _service.Remove(validGuid);

        // Assert
        Assert.IsType<Book>(okResult);
        Assert.Equal(4, _service.GetAll().Count());
    }
}