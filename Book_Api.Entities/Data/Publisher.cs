using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Publisher : IEntity
    {
       [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}
