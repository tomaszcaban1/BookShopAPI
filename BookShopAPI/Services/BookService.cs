using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShopAPI.Constants;
using BookShopAPI.Entities;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Exceptions;
using BookShopAPI.Guards.Interfaces;
using BookShopAPI.Models.Book;
using BookShopAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShopAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IBookServiceGuard _bookServiceGuard;

        public BookService(BookShopDbContext dbContext, IMapper mapper, IBookServiceGuard bookServiceGuard)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _bookServiceGuard = bookServiceGuard;
        }

        public IEnumerable<BookDto> GetAll(int bookShopId)
        {
            var bookShop = GetBookShopIncludeBooksById(bookShopId);

            var books = bookShop.Books;

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return booksDto;
        }

        public BookDto GetById(int bookShopId, int bookId)
        {
            var bookShop = GetBookShopIncludeBooksById(bookShopId);
            var book = GetBookFromBookShopById(bookShop, bookId);

            var booksDto = _mapper.Map<BookDto>(book);

            return booksDto;
        }

        public int Create(int bookShopId, CreateBookDto createBookDto)
        {
            _bookServiceGuard.CheckBookShopExistsById(bookShopId);

            var bookEntity = _mapper.Map<Book>(createBookDto);
            bookEntity.BookShopId = bookShopId;

            _dbContext.Books.Add(bookEntity);
            _dbContext.SaveChanges();

            return bookEntity.Id;
        }

        public void DeleteAll(int bookShopId)
        {
            var bookShop = GetBookShopIncludeBooksById(bookShopId);

            _dbContext.RemoveRange(bookShop.Books);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int bookShopId, int bookId)
        {
            var bookShop = GetBookShopIncludeBooksById(bookShopId);
            var book = GetBookFromBookShopById(bookShop, bookId);

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        private Book GetBookFromBookShopById(BookShop bookShop, int bookId)
        {
            var book = bookShop.Books.FirstOrDefault(b => b.Id == bookId);
            if (book is null)
                throw new NotFoundException(ExceptionMessage.BookNotFound);

            return book;
        }

        private BookShop GetBookShopIncludeBooksById(int bookShopId)
        {
            var bookShop = _dbContext.BookShops
                .Include(b => b.Books)
                .FirstOrDefault(s => s.Id == bookShopId);

            if (bookShop is null)
                throw new NotFoundException(ExceptionMessage.BookShopNotFound);

            return bookShop;
        }
    }
}
