using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
        
        public string UserId { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }

    }
}
