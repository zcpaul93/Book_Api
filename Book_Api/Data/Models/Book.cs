using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required,StringLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Rating { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal PriceBeforeDiscount { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Cover { get; set; }
        public string PaperType { get; set; }
        public string Size { get; set; }
        public int PageCount { get; set; }
        public string Dimensions { get; set; }
        public int Weight { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfIssue { get; set; }
        

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    
    }
}
