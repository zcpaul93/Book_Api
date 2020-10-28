using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Entities.ComplexTypes
{
    public class BookWithCount
    {
        public List<Book> Books { get; set; }
        public int BookCount { get; set; }
    }
}
