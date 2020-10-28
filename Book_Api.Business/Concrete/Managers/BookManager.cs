using Book_Api.Business.Abstract;
using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using Book_Api.Entities.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Book_Api.Business.Concrete.Managers
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Add(Book book)
        {
            return _bookRepository.Add(book);
        }
        public List<Book> GetAll()
        {
            return _bookRepository.GetAllQuery()
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }

        public List<Book> GetNewBooks() 
        {
            return _bookRepository.GetAllQuery()
                .OrderByDescending(b => b.DateOfIssue)
                .Take(6)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }
        public List<Book> GetTopSaleBooks()
        {
            return _bookRepository.GetAllQuery()
                .OrderByDescending(b => b.SellCount)
                .Take(12)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }
        public List<Book> GetMyChooseBooks()
        {
            return _bookRepository.GetAllQuery()
                .Where(b => b.MyChoose == true)
                .Take(6)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }
        public Book GetById(int id)
        {
            return _bookRepository.Get(b => b.BookId == id);
        }

    

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public void Remove(Book book)
        {
             _bookRepository.Delete(book);
        }

        public BookWithCount GetAllByFilterType(BookFilterModel bookFilterModel)
        {
            return _bookRepository.GetAllByFilterOrderBy(bookFilterModel);
        }

        public BookWithCount GetAllByFilterAZ(BookFilterModel bookFilterModel)
        {
            return _bookRepository.GetAllByFilterOrderBy(bookFilterModel, b => b.Name);
        }

        public BookWithCount GetAllByFilterZA(BookFilterModel bookFilterModel)
        {
            return _bookRepository.GetAllByFilterOrderByDesc(bookFilterModel, b => b.Name);
        }

        public BookWithCount GetAllByFilterPriceUpToDown(BookFilterModel bookFilterModel)
        {
            return _bookRepository.GetAllByFilterOrderByDesc(bookFilterModel, b => b.Price);
        }

        public BookWithCount GetAllByFilterPriceDownToUp(BookFilterModel bookFilterModel)
        {
            return _bookRepository.GetAllByFilterOrderBy(bookFilterModel, b => b.Price);
        }

        public Book GetBookByIdWithAuthorPublisher(int id)
        {
            return _bookRepository.GetBookWithAuthorPublisher(b => b.BookId == id);
        }

        public List<Book> GetBooksByNameTextSearch(string search)
        {
            return _bookRepository.GetBooksWithFilter(b => b.Name.Contains(search));
        }
    }
}
