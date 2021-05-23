using System.Collections.Generic;
using BookShopAPI.Entities;
using BookShopAPI.Models.Book;

namespace BookShopAPI.Models.BookShop
{
    public class BookShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public virtual IEnumerable<BookDto> Books { get; set; }
    }
}
