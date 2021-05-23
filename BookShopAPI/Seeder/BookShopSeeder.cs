using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopAPI.Entities;
using BookShopAPI.Entities.DbContext;

namespace BookShopAPI.Seeder
{
    public class BookShopSeeder
    {
        private readonly BookShopDbContext _dbContext;

        public BookShopSeeder(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.BookShops.Any())
                {
                    var mainBookShop = GetMainBookShop();
                    _dbContext.BookShops.AddRange(mainBookShop);
                    _dbContext.SaveChanges();
                }
            }
        }

        private BookShop GetMainBookShop()
        {
            var mainBookShop = new BookShop()
            {
                Name = "Copernicus Center Press",
                Description = "Main bookshop",
                Address = new Address()
                {
                    City = "Wrocław",
                    Street = "Sztabowa",
                    StreetNumber = 98,
                    PostalCode = "53-310"
                },
                Contact = new Contact()
                {
                    ContactEmail = "ccp@bookshop.wroc.pl",
                    ContactNumber1 = "71 354 72 71",
                    ContactNumber2 = "71 364 69 73"
                },
                Books = new List<Book>()
                {
                    new Book()
                    {
                        Title = "Do końca czasu",
                        Description = "Umysł, materia i nasze poszukiwanie sensu w zmieniającym się Wszechświecie",
                        Author = "Brian Greene",
                        Price = 50,
                        ClassifiedInformation = "Something important"
                    },
                    new Book()
                    {
                        Title = "Wszechświat krok po kroku",
                        Author = "Łukasz Lamża",
                        Price = 30,
                        ClassifiedInformation = "Something important"
                    },
                    new Book()
                    {
                        Title = "Pan raczy żartować, panie Feynman! ",
                        Author = "Richard Feynman",
                        Price = 100
                    }

                }
            };

            return mainBookShop;
        }
    }
}
