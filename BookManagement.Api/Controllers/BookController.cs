using BookManagement.Api.Examples;
using BookManagement.App.DTOs;
using BookManagement.App.IServices;
using BookManagement.App.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace BookManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create-book")]
        [SwaggerRequestExample(typeof(CreateBookDto), typeof(CreateBookExample))]
        public async Task<IActionResult> CreateBook([FromBody]CreateBookDto book, [FromServices]CreateBookValidation validator)
        {
            var validationResult = await validator.ValidateAsync(book);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _bookService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookService.GetBookById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("update-book/{id}")]
        [SwaggerRequestExample(typeof(UpdateBookDto), typeof(UpdateBookExample))]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]UpdateBookDto book, [FromServices]UpdateBookValidation validator)
        {
            var validationResult = await validator.ValidateAsync(book);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _bookService.UpdateBook(id, book);
            return Ok();
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
