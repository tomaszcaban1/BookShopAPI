using System.Collections.Generic;

namespace BookShopAPI.Entities
{
    public class BookShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
