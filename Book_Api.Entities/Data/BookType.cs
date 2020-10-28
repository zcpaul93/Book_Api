using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class BookType
    {
        public int BookId { get; set; }
        public int TypesId { get; set; }

        public Book Book { get; set; }
        public Types Types { get; set; }
    }
}
