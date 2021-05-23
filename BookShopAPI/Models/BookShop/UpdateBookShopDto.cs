using System.ComponentModel.DataAnnotations;

namespace BookShopAPI.Models.BookShop
{
    public class UpdateBookShopDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
