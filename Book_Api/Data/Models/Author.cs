using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string FirstName { get; set; }
        [Required, StringLength(20)]
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
