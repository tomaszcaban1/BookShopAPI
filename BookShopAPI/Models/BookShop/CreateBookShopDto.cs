using System.ComponentModel.DataAnnotations;

namespace BookShopAPI.Models.BookShop
{
    public class CreateBookShopDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactNumber1 { get; set; }
        [Phone]
        public string ContactNumber2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
