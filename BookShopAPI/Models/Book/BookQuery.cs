using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopAPI.Models.Book
{
    public class BookQuery
    {
        public string SearchAuthor { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
