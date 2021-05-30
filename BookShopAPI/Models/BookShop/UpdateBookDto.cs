using System.ComponentModel.DataAnnotations;

namespace BookShopAPI.Models.Book
{
    public class UpdateBookDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
