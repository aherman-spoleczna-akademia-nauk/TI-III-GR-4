using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? title)
        {
            var books = _bookService.GetBooks(title);
            if (books.Count == 0)
                return NoContent();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookCommand command)
        {
            var result = _bookService.AddNewBook(command);
            if (!result.Success)
                return BadRequest(result.Error);

            return Created();
        }


    }
}
