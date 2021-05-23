using System.Collections.Generic;
using BookShopAPI.Models.Book;

namespace BookShopAPI.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll(int bookShopId);
        BookDto GetById(int bookShopId, int bookId);
        int Create(int bookShopId, CreateBookDto createBookDto);
        void DeleteAll(int bookShopId);
        void DeleteById(int bookShopId, int bookId);
    }
}