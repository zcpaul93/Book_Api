using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.ViewModels.Book
{
    public class AddBookViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public decimal PriceBeforeDiscount { get; set; }
        public int Discount { get; set; }
        public string ISBN { get; set; }
        public string Cover { get; set; }
        public string PaperType { get; set; }
        public string Size { get; set; }
        public int PageCount { get; set; }
        public string Dimensions { get; set; }
        public int Weight { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int Stock { get; set; }
        public int SellCount { get; set; }
        public string Slug { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public List<Types> TypeIdList { get; set; }
    }
}
