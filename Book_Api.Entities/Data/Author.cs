using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Author : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
     
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
