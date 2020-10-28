using Book_Api.Data.Models;
using Book_Api.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book_Api.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<int> AddBook(AddBookViewModel book);
        Task<BooksAndCountViewModel>  GetBooksFilterBy_Type(int typeId, int pageCount, int pageSize = 12);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Price(int typeId, int pageCount, int pageSize = 12, decimal? maxPrice = 0, decimal? minPrice = 0);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0);
        Task<BooksAndCountViewModel> GetBooksFilterBy_Type_Author_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0);
 
    }
}
