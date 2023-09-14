using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBookService _service;

    public BooksController(ILogger<BooksController> logger, IBookService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
        var books = _service.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(Guid id)
    {
        var book = _service.GetById(id);
        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public ActionResult Post(Book value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var book = _service.Add(value);
        return CreatedAtAction("Get", new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    public ActionResult Remove(Guid id)
    {
        var book = _service.GetById(id);

        if (book is null)
            return NotFound();

        _service.Remove(id);
        return Ok();
    }
}
