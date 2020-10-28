using Book_Api.Core.DataAccess.EntityFramework;
using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using Book_Api.Entities.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Book_Api.DataAccess.Concrete.EntityFramework
{
    public class EfBookRepository : EfEntityRepositoryBase<Book> ,IBookRepository
    {
        private readonly BookDbContext _context;
        public EfBookRepository(BookDbContext context):base(context)
        {
            _context = context;
        }

        public Book GetBookWithAuthorPublisher(Expression<Func<Book, bool>> filter)
        {
            var book = _context.Books
                .Where(filter)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault();

            return book;
        }

        public IQueryable<Book> FilterQuery(BookFilterModel model)
        {
            var books = from b in _context.Books
                        join bt in _context.BookTypes on b.BookId equals bt.BookId
                        join t in _context.Types on bt.TypesId equals t.TypesId
                        join a in _context.Authors on b.AuthorId equals a.Id
                        join p in _context.Publishers on b.PublisherId equals p.Id
                        where t.TypesId == model.TypeId &&
                        b.Price >= (model.MinPrice != 0 ? model.MinPrice : b.Price) &&
                        b.Price <= (model.MaxPrice != 0 ? model.MaxPrice : b.Price) &&
                        (model.Authors.Count != 0
                            ? model.Authors.Contains(b.AuthorId)
                            : b.AuthorId == b.AuthorId) &&
                        (model.Publishers.Count != 0
                            ? model.Publishers.Contains(b.PublisherId)
                            : b.PublisherId == b.PublisherId)
                        //b.AuthorId == (model.Authors.Count != 0 ? model.Authors[0] : b.AuthorId) &&
                        //b.PublisherId == (model.Publishers.Count != 0 ? model.Publishers[0] : b.PublisherId)
                        select b;
            
            return books;
        }

        public BookWithCount GetAllByFilterOrderBy(BookFilterModel bookFilterModel, 
            Expression<Func<Book, dynamic>> filter = null)
        {
            var books = filter != null
                ? FilterQuery(bookFilterModel)
                     .Skip((bookFilterModel.PageCount - 1) * bookFilterModel.PageSize)
                     .Take(bookFilterModel.PageSize)
                     .OrderBy(filter)
                     .Include(b => b.Author)
                     .Include(b => b.Publisher)
                     .ToList()
                
                 : FilterQuery(bookFilterModel)
                     .Skip((bookFilterModel.PageCount - 1) * bookFilterModel.PageSize)
                     .Take(bookFilterModel.PageSize)
                     .Include(b => b.Author)
                     .Include(b => b.Publisher)
                     .ToList();

            var bookCount = FilterQuery(bookFilterModel).Count();
            var bookWithCount = new BookWithCount
            {
                Books = books,
                BookCount = bookCount
            };

            return bookWithCount;
        }

        public BookWithCount GetAllByFilterOrderByDesc(BookFilterModel bookFilterModel, 
            Expression<Func<Book, dynamic>> filter = null)
        {
            var books = filter != null
                ? FilterQuery(bookFilterModel)
                     .Skip((bookFilterModel.PageCount - 1) * bookFilterModel.PageSize)
                     .Take(bookFilterModel.PageSize)
                     .OrderByDescending(filter)
                     .Include(b => b.Author)
                     .Include(b => b.Publisher)
                     .ToList()
                : FilterQuery(bookFilterModel)
                     .Skip((bookFilterModel.PageCount - 1) * bookFilterModel.PageSize)
                     .Take(bookFilterModel.PageSize)
                     .OrderByDescending(filter)
                     .Include(b => b.Author)
                     .Include(b => b.Publisher)
                     .ToList();

            var bookCount = FilterQuery(bookFilterModel).Count();
            var bookWithCount = new BookWithCount
            {
                Books = books,
                BookCount = bookCount
            };

            return bookWithCount;
        }

        public List<Book> GetBooksWithFilter(Expression<Func<Book, bool>> filter)
        {
            var books = _context.Books
                .Where(filter)
                .ToList();

            return books;
        }
    }
}
