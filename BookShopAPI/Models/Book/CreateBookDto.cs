using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAPI.Models.Book
{
    public class CreateBookDto : BookDto
    {
        public int RestaurantId { get; set; }
        [Required]
        [MaxLength(100)]
        public new string Title { get; set; }
    }
}
