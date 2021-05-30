using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopAPI.Models.Book;
using BookShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{

    [Route("api/SQL/BookShop/{bookShopId:int}/[controller]")]
    [ApiController]
    public class BookSqlController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookSqlController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks([FromRoute] int bookShopId, [FromQuery] BookQuery bookQuery)
        {
            var bookDtos = _bookService.GetAllBySQL(bookShopId, bookQuery);

            return Ok(bookDtos);
        }
    }
}

