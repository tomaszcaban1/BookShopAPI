using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShopAPI.Models.Book;
using BookShopAPI.Services.Interfaces;

namespace BookShopAPI.Controllers
{
    [Route("api/BookShop/{bookShopId:int}/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks([FromRoute] int bookShopId, [FromQuery] BookQuery bookQuery)
        {
            var bookDtos = _bookService.GetAll(bookShopId, bookQuery);

            return Ok(bookDtos);
        }

        [HttpGet("{bookId:int}")]
        public ActionResult<BookDto> GetBookById([FromRoute] int bookShopId, [FromRoute] int bookId)
        {
            var bookDto = _bookService.GetById(bookShopId, bookId);

            return Ok(bookDto);
        }

        [HttpPost]
        public ActionResult CreateBook([FromRoute] int bookShopId, CreateBookDto createBookDto)
        {
            var newBookId = _bookService.Create(bookShopId, createBookDto);

            return Created($"api/BookShop/{bookShopId}/Book/{newBookId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAllBooks([FromRoute] int bookShopId)
        {
            _bookService.DeleteAll(bookShopId);

            return NoContent();
        }

        [HttpDelete("{bookId:int}")]
        public ActionResult DeleteBook([FromRoute] int bookShopId, [FromRoute] int bookId)
        {
            _bookService.DeleteById(bookShopId, bookId);

            return NoContent();
        }

        [HttpPut("{bookId:int}")]
        public ActionResult UpdateBook([FromRoute] int bookShopId, [FromRoute] int bookId, [FromBody] UpdateBookDto updateBookDto)
        {
            _bookService.Update(bookShopId, bookId, updateBookDto);

            return Ok();
        }
    }
}
