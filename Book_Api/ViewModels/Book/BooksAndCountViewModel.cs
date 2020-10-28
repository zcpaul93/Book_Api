using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace Book_Api.ViewModels.Book
{
    public class BooksAndCountViewModel
    {
        public List<Book_Api.Data.Models.Book> Book { get; set; }
        public int Count { get; set; }
        public List<Book_Api.Data.Models.Book> Query { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
