using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Book : IEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required,StringLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Rating { get; set; }
        public int RatingTotalCount { get; set; }
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
        public int Stock { get; set; }
        public int SellCount { get; set; }
        public bool MyChoose { get; set; }
        [Required]
        public string Slug { get; set; }
        
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    
    }
}
