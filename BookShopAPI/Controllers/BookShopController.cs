using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShopAPI.Models.BookShop;
using BookShopAPI.Services.Interfaces;

namespace BookShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShopController : ControllerBase
    {
        private readonly IBookShopService _bookShopService;

        public BookShopController(IBookShopService bookShopService)
        {
            _bookShopService = bookShopService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookShopDto>> GetBookShops()
        {
            var bookShopDtos = _bookShopService.GetAll();

            return Ok(bookShopDtos);
        }

        [HttpGet("{bookShopId:int}")]
        public ActionResult<BookShopDto> GetBookShopById([FromRoute] int bookShopId)
        {
            var bookShopDto = _bookShopService.GetById(bookShopId);

            return Ok(bookShopDto);
        }

        [HttpPost]
        public ActionResult CreateBookShop([FromBody] CreateBookShopDto createBookShopDto)
        {
            var newBookShopId = _bookShopService.Create(createBookShopDto);

            return Created($"api/BookShop/{newBookShopId}", null);
        }

        [HttpDelete("{bookShopId:int}")]
        public ActionResult DeleteBookShop([FromRoute] int bookShopId)
        {
            _bookShopService.Delete(bookShopId);

            return NoContent();
        }

        [HttpPut("{bookShopId:int}")]
        public ActionResult UpdateBookShop([FromRoute] int bookShopId, [FromBody] UpdateBookShopDto updateBookShopDto)
        {
            _bookShopService.Update(bookShopId, updateBookShopDto);
            
            return Ok();
        }
    }
}
