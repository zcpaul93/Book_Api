using Book_Api.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Helpers
{
    public static class FilterHelper
    {
        public static BooksAndCountViewModel OrderAZ(BooksAndCountViewModel books) 
        {
            var booksOrder = new BooksAndCountViewModel()
            {
                Book = books.Query.OrderBy(b => b.Name)
                  .Skip((books.PageCount - 1) * books.PageSize)
                  .Take(books.PageSize)
                  .ToList(),
                Count = books.Count
            };

            return booksOrder;
        }
        public static BooksAndCountViewModel OrderZA(BooksAndCountViewModel books)
        {
            var booksOrder = new BooksAndCountViewModel()
            {
                Book = books.Query.OrderByDescending(b => b.Name)
                  .Skip((books.PageCount - 1) * books.PageSize)
                  .Take(books.PageSize)
                  .ToList(),
                Count = books.Count
            };

            return booksOrder;
        }
        public static BooksAndCountViewModel OrderUpPrice(BooksAndCountViewModel books)
        {
            var booksOrder = new BooksAndCountViewModel()
            {
                Book = books.Query.OrderBy(b => b.Price)
                              .Skip((books.PageCount - 1) * books.PageSize)
                              .Take(books.PageSize)
                              .ToList(),
                Count = books.Count
            };

            return booksOrder;
        }
        public static BooksAndCountViewModel OrderDownPrice(BooksAndCountViewModel books)
        {
            var booksOrder = new BooksAndCountViewModel()
            {
                Book = books.Query.OrderByDescending(b => b.Price)
                              .Skip((books.PageCount - 1) * books.PageSize)
                              .Take(books.PageSize)
                              .ToList(),
                Count = books.Count
            };

            return booksOrder;
        }
        public static BooksAndCountViewModel OrderTopSale(BooksAndCountViewModel books)
        {
            var booksOrder = new BooksAndCountViewModel()
            {
                Book = books.Query.OrderByDescending(b => b.SellCount)
                              .Skip((books.PageCount - 1) * books.PageSize)
                              .Take(books.PageSize)
                              .ToList(),
                Count = books.Count
            };

            return booksOrder;
        }
    }
}
