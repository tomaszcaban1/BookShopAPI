using System.Runtime.InteropServices.ComTypes;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Exceptions;
using BookShopAPI.Guards;
using BookShopAPI.Seeder;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BookShopAPI.Tests.Guard.Tests
{
    public class BookServiceGuardTests : TestBase
    {
        private readonly DbContextOptions<BookShopDbContext> _dbContextOptions = new DbContextOptionsBuilder<BookShopDbContext>()
            .UseInMemoryDatabase(databaseName: Constants.Constants.DatabaseName)
            .Options;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();
        }

        [SetUp]
        public void Init()
        {
            TestContext.WriteLine("In TestInitialize() method");
            WriteDescription(this.GetType());
        }

        private void SeedDb()
        {
            using var context = new BookShopDbContext(_dbContextOptions);
            var bookShops = new BookShopSeeder(context);

            bookShops.Seed();
        }

        [Test, Description("Check to throw exception NotFoundException when BookShop does not exists")]
        public void ThrowExceptionWhenBookShopDoesNotExists()
        {
            using var context = new BookShopDbContext(_dbContextOptions);
            var sut = new BookServiceGuard(context);
            var bookShopId = Constants.Constants.BookShopIdDoNotExists;

            Assert.Throws<NotFoundException>(() => sut.CheckBookShopExistsById(bookShopId));
        }

        [Test, Description("Check to do NOT throw exception NotFoundException when BookShop exists")]
        public void DoNotThrowExceptionWhenBookShopExists()
        {
            using var context = new BookShopDbContext(_dbContextOptions);
            var sut = new BookServiceGuard(context);
            var bookShopId = Constants.Constants.BookShopIdExists;

            Assert.DoesNotThrow(() => sut.CheckBookShopExistsById(bookShopId));
        }
    }
}
