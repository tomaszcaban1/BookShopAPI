using System.Linq;
using AutoMapper;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Guards.Interfaces;
using BookShopAPI.Mapping;
using BookShopAPI.Seeder;
using BookShopAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BookShopAPI.Tests.Services.Tests
{
    public class BookServiceTests
    {
        private readonly DbContextOptions<BookShopDbContext> _dbContextOptions = new DbContextOptionsBuilder<BookShopDbContext>()
            .UseInMemoryDatabase(databaseName: Constants.Constants.DatabaseName)
            .Options;

        protected BookService _bookService;
        private static IMapper _mapper;
        private readonly BookShopDbContext _bookShopBdContext;

        public BookServiceTests()
        {
            CreateMapper();
            _bookShopBdContext = new BookShopDbContext(_dbContextOptions);
        }

        private static void CreateMapper()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookShopMappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();

            var mockBookServiceGuard = new Mock<IBookServiceGuard>();
            _bookService = new BookService(_bookShopBdContext, _mapper, mockBookServiceGuard.Object);
        }

        private void SeedDb()
        {
            using var context = new BookShopDbContext(_dbContextOptions);
            var bookShops = new BookShopSeeder(context);

            bookShops.Seed();
        }

        protected int GetMaxBookId()
        {
            return _bookShopBdContext.Books.Max(x => x.Id);
        }

        protected int GetBooksCount()
        {
            return _bookShopBdContext.Books.Count();
        }

        protected bool IsBookExist(int bookId)
        {
            return _bookShopBdContext.Books.Any(x => x.Id == bookId);
        }
    }
}
