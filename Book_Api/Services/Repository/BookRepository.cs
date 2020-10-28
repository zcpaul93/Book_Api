using Book_Api.Data;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Concrete.EntityFramework;
using Book_Api.IRepository;
using Book_Api.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Repository
{
    public class BookRepository : IBookRepository
    {
        readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.BookId == id);
            
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();

            return books;
        }
 
        public async Task<BooksAndCountViewModel>  GetBooksFilterBy_Type(int typeId, int pageCount, int pageSize = 12)
        {
            var books = new BooksAndCountViewModel();
            var query = await _context.Books
                              .Include(b => b.Author)
                              .Include(b => b.Publisher)
                              .Where(b =>
                                _context.BookTypes
                                .Where(bt =>
                                    _context.Types
                                    .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                .Select(bt => bt.BookId).Contains(b.BookId))
                                .ToListAsync();
                              
        
            books.Count = query.Count;
            books.Book = query.Skip((pageCount - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();
            books.Query = query;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;

        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var authorId in authorIdList)
            {
                foreach (var publisherId in publisherIdList)
                {
                    var query = await _context.Books
                      .Include(b => b.Author)
                      .Include(b => b.Publisher)
                      .Where(b =>
                        _context.BookTypes
                        .Where(bt =>
                            _context.Types
                            .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                        .Select(bt => bt.BookId).Contains(b.BookId)
                        && b.Author.Id == authorId && b.Publisher.Id == publisherId)
                      .ToListAsync();

                      bookList.AddRange(query);
                }

            }

            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var authorId in authorIdList)
            {
                var query = await _context.Books
                                  .Include(b => b.Author)
                                  .Include(b => b.Publisher)
                                  .Where(b =>
                                    _context.BookTypes
                                    .Where(bt =>
                                        _context.Types
                                        .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                    .Select(bt => bt.BookId).Contains(b.BookId)
                                    && b.Author.Id == authorId)
                                  .ToListAsync();

                bookList.AddRange(query);
            }

            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                                  .Take(pageSize)
                                  .OrderBy(b => b.Name)
                                  .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var publisherId in publisherIdList)
            {
                var query = await _context.Books
                                  .Include(b => b.Author)
                                  .Include(b => b.Publisher)
                                  .Where(b =>
                                    _context.BookTypes
                                    .Where(bt =>
                                        _context.Types
                                        .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                    .Select(bt => bt.BookId).Contains(b.BookId)
                                    && b.Publisher.Id == publisherId)
                                  .ToListAsync();

                bookList.AddRange(query);
            }

            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                                  .Take(pageSize)
                                  .OrderBy(b => b.Name)
                                  .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Price(int typeId, int pageCount, int pageSize = 12, decimal? maxPrice = 0, decimal? minPrice=0)
        {
            var books = new BooksAndCountViewModel();
            var query = await _context.Books
                         .Include(b => b.Author)
                         .Include(b => b.Publisher)
                         .Where(b =>
                           _context.BookTypes
                           .Where(bt =>
                               _context.Types
                               .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                           .Select(bt => bt.BookId).Contains(b.BookId))
                         .Where(b => b.Price >= minPrice && b.Price < maxPrice) 
                         .ToListAsync();

            books.Book = query.Skip((pageCount - 1) * pageSize)
                              .Take(pageSize)
                              .OrderBy(b => b.Name)
                              .ToList();
            books.Count = query.Count();
            books.Query = query;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;

        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var authorId in authorIdList)
            {
                var query = await _context.Books
                                  .Include(b => b.Author)
                                  .Include(b => b.Publisher)
                                  .Where(b =>
                                    _context.BookTypes
                                    .Where(bt =>
                                        _context.Types
                                        .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                    .Select(bt => bt.BookId).Contains(b.BookId)
                                    && b.Author.Id == authorId)
                                  .Where(b => b.Price >= minPrice && b.Price < maxPrice)
                                  .ToListAsync();

                bookList.AddRange(query);
            }


            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                              .Take(pageSize)
                              .OrderBy(b => b.Name)
                              .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var publisherId in publisherIdList)
            {
                var query = await _context.Books
                                  .Include(b => b.Author)
                                  .Include(b => b.Publisher)
                                  .Where(b =>
                                    _context.BookTypes
                                    .Where(bt =>
                                        _context.Types
                                        .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                    .Select(bt => bt.BookId).Contains(b.BookId)
                                    && b.Publisher.Id == publisherId)
                                   .Where(b => b.Price >= minPrice && b.Price < maxPrice)
                                  .ToListAsync();

                bookList.AddRange(query);
            }

            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                              .Take(pageSize)
                              .OrderBy(b => b.Name)
                              .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }
        public async Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            var books = new BooksAndCountViewModel();
            List<Book> bookList = new List<Book>();

            foreach (var authorId in authorIdList)
            {
                foreach (var publisherId in publisherIdList)
                {
                    var query = await _context.Books
                                      .Include(b => b.Author)
                                      .Include(b => b.Publisher)
                                      .Where(b =>
                                        _context.BookTypes
                                        .Where(bt =>
                                            _context.Types
                                            .Where(t => t.TypesId == typeId).Select(t => t.TypesId).Contains(bt.TypesId))
                                        .Select(bt => bt.BookId).Contains(b.BookId)
                                        && b.Publisher.Id == publisherId && b.Author.Id == authorId)
                                       .Where(b => b.Price >= minPrice && b.Price < maxPrice)
                                      .ToListAsync();

                    bookList.AddRange(query);
                }
            }


            books.Book = bookList.Skip((pageCount - 1) * pageSize)
                              .Take(pageSize)
                              .OrderBy(b => b.Name)
                              .ToList();
            books.Count = bookList.Count();
            books.Query = bookList;
            books.PageSize = pageSize;
            books.PageCount = pageCount;

            return books;
        }

        public async Task<int> AddBook(AddBookViewModel model)
        {
            var book = new Book()
            {
                AuthorId = model.AuthorId,
                Cover = model.Cover,
                DateOfIssue = model.DateOfIssue,
                Description = model.Description,
                Dimensions = model.Dimensions,
                Discount = model.Discount,
                ImagePath = model.ImagePath,
                ISBN = model.ISBN,
                Name = model.Name,
                PageCount = model.PageCount,
                PaperType = model.PaperType,
                Price = model.Price,
                PriceBeforeDiscount = model.PriceBeforeDiscount,
                PublisherId = model.PublisherId,
                Rating = model.Rating,
                SellCount = model.SellCount,
                Size = model.Size,
                Slug = model.Slug,
                Stock = model.Stock,
                Weight = model.Weight
            };


            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            // inserted book
            int id = book.BookId;

            foreach (var type in model.TypeIdList)
            {
                var bookType = new BookType
                {
                    BookId = id,
                    TypesId = type.TypesId
                };
                _context.BookTypes.Add(bookType);
            }
            await _context.SaveChangesAsync();
            return book.BookId;
        }


    }
}
