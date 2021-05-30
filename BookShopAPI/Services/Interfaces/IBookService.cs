using System.Collections.Generic;
using BookShopAPI.Models;
using BookShopAPI.Models.Book;

namespace BookShopAPI.Services.Interfaces
{
    public interface IBookService
    {
        PageResult<BookDto> GetAll(int bookShopId, BookQuery bookQuery);
        BookDto GetById(int bookShopId, int bookId);
        int Create(int bookShopId, CreateBookDto createBookDto);
        void DeleteAll(int bookShopId);
        void DeleteById(int bookShopId, int bookId);
        void Update(int bookShopId, int bookId, UpdateBookDto updateBookDto);
        PageResult<BookDto> GetAllBySQL(int bookShopId, BookQuery bookQuery);
    }
}