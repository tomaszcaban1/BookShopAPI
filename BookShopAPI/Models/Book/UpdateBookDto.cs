using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAPI.Models.Book
{
    public class UpdateBookDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
