using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookShopAPI.Tests.Services.Tests
{
    public class BookServiceDeleteTests : BookServiceTests
    {
        [Test]
        public void ShouldDeleteBookById()
        {
            // arrange
            var lastBookIdBeforeDelete = GetMaxBookId();
            var bookCountBeforeDelete = GetBooksCount();

            // act
            _bookService.DeleteById(Constants.Constants.BookShopIdExists, lastBookIdBeforeDelete);
            var lastBookIdAfterDelete = lastBookIdBeforeDelete - 1;
            var expectedBookId = GetMaxBookId();
            var bookCountAfterDelete = bookCountBeforeDelete - 1;
            var expectedBookCount = GetBooksCount();

            // assert
            Assert.AreEqual(expectedBookId, lastBookIdAfterDelete);
            Assert.AreEqual(expectedBookCount, bookCountAfterDelete);
            Assert.False(IsBookExist(lastBookIdBeforeDelete));
        }
    }
}
