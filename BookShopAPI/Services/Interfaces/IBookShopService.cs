using System.Collections.Generic;
using BookShopAPI.Models.BookShop;

namespace BookShopAPI.Services.Interfaces
{
    public interface IBookShopService
    {
        IEnumerable<BookShopDto> GetAll();
        BookShopDto GetById(int id);
        int Create(CreateBookShopDto createBookShopDto);
        void Delete(int id);
        void Update(int id, UpdateBookShopDto updateBookShopDto);
    }
}