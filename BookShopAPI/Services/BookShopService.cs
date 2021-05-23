using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookShopAPI.Constants;
using BookShopAPI.Entities;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Exceptions;
using BookShopAPI.Models.BookShop;
using BookShopAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookShopAPI.Services
{
    public class BookShopService : IBookShopService
    {
        private readonly BookShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BookShopService> _logger;

        public BookShopService(BookShopDbContext dbContext, IMapper mapper, ILogger<BookShopService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<BookShopDto> GetAll()
        {
            var bookShops = _dbContext
                .BookShops
                .Include(s => s.Contact)
                .Include(s => s.Address)
                .Include(s => s.Books)
                .ToList();

            var bookShopsDtos = _mapper.Map<List<BookShopDto>>(bookShops);

            return bookShopsDtos;
        }

        public BookShopDto GetById(int bookShopId)
        {
            var bookShop = _dbContext
                .BookShops
                .Include(s => s.Contact)
                .Include(s => s.Address)
                .Include(s => s.Books)
                .FirstOrDefault(s => s.Id == bookShopId);

            if (bookShop is null)
                throw new NotFoundException(ExceptionMessage.BookShopNotFound);

            var bookShopDto = _mapper.Map<BookShopDto>(bookShop);

            return bookShopDto;
        }

        public int Create(CreateBookShopDto createBookShopDto)
        {
            var bookShopEntity = _mapper.Map<BookShop>(createBookShopDto);

            _dbContext.BookShops.Add(bookShopEntity);
            _dbContext.SaveChanges();

            return bookShopEntity.Id;
        }

        public void Delete(int bookShopId)
        {
            _logger.LogWarning(string.Concat(LogMessage.DeleteAction, $"{bookShopId}"));

            var bookShop = GetBookShopById(bookShopId);

            _dbContext.BookShops.Remove(bookShop);
            _dbContext.SaveChanges();
        }

        public void Update(int bookShopId, UpdateBookShopDto updateBookShopDto)
        {
            var bookShop = GetBookShopById(bookShopId);

            bookShop.Name = updateBookShopDto.Name;
            bookShop.Description = updateBookShopDto.Description;

            _dbContext.SaveChanges();
        }

        private BookShop GetBookShopById(int bookShopId)
        {
            var bookShop = _dbContext
                .BookShops
                .FirstOrDefault(s => s.Id == bookShopId);

            if (bookShop is null)
                throw new NotFoundException(ExceptionMessage.BookShopNotFound);

            return bookShop;
        }
    }
}
