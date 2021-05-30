using BookShopAPI.Models.Book;
using NUnit.Framework;

namespace BookShopAPI.Tests.Services.Tests
{
    public class BookServiceCreateTests : BookServiceTests
    {
        [Test]
        public void ShouldReturnCorrectIdWhenCreateNewBook()
        {
            // arrange
            var createBookDto = new CreateBookDto()
            {
                Title = "TEST",
                Description = "TEST",
                Author = "TEST",
                Price = 10,
                RestaurantId = 1
            };
            var lastBookIdBeforeCreate = GetMaxBookId();
            var booksCountBeforeCreate = GetBooksCount();

            // act
            var result = _bookService.Create(Constants.Constants.BookShopIdExists, createBookDto);
            var booksCountAfterCreate = GetBooksCount();
            var expectedBooksCountAfterCreate = booksCountBeforeCreate + 1;

            // assert
            Assert.AreEqual(expectedBooksCountAfterCreate, booksCountAfterCreate);
            Assert.Greater(result, lastBookIdBeforeCreate);
        }
    }
}
