using BookShopAPI.Exceptions;
using BookShopAPI.Models.Book;
using FluentAssertions;
using NUnit.Framework;

namespace BookShopAPI.Tests.Services.Tests
{
    public class BookServiceGetTests : BookServiceTests
    {
        [Test]
        public void ShouldReturnCorrectBookDtoById()
        {
            // arrange
            var expectedBookDto = new BookDto()
            {
                Id = 1,
                Title = "Do końca czasu",
                Description = "Umysł, materia i nasze poszukiwanie sensu w zmieniającym się Wszechświecie",
                Author = "Brian Greene",
                Price = 50,
            };

            // act
            var result = _bookService.GetById(Constants.Constants.BookShopIdExists, Constants.Constants.BookIdExists);

            // assert
            result.Should().NotBeNull();
            Assert.IsInstanceOf<BookDto>(result);
            result.Should().BeEquivalentTo(expectedBookDto);
        }

        [Test]
        public void ShouldThrowExceptionWhenBookIdDoesNotExist()
        {
            // assert
            Assert.Throws<NotFoundException>(() => _bookService
                .GetById(Constants.Constants.BookShopIdExists, Constants.Constants.BookIdNotExists));
        }

        [Test]
        public void ShouldThrowExceptionWhenBookShopIdDoesNotExist()
        {
            // assert
            Assert.Throws<NotFoundException>(() => _bookService
                .GetById(Constants.Constants.BookShopIdDoNotExists, Constants.Constants.BookIdExists));
        }

    }
}
