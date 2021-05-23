using System.Linq;
using BookShopAPI.Constants;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Exceptions;
using BookShopAPI.Guards.Interfaces;

namespace BookShopAPI.Guards
{
    public class BookServiceGuard : IBookServiceGuard
    {
        private readonly BookShopDbContext _dbContext;

        public BookServiceGuard(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CheckBookShopExistsById(int bookShopId)
        {
            var bookShop = _dbContext.BookShops
                .FirstOrDefault(s => s.Id == bookShopId);

            if (bookShop is null)
                throw new NotFoundException(ExceptionMessage.BookShopNotFound);
        }
    }
}
