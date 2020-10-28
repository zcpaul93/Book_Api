using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Book_Api.Entities.ComplexTypes;
using System.Collections.Generic;

namespace Book_Api.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<Book> GetNewBooks();
        List<Book> GetTopSaleBooks();
        List<Book> GetMyChooseBooks();
        List<Book> GetBooksByNameTextSearch(string search);
        Book GetById(int id);
        Book GetBookByIdWithAuthorPublisher(int id);
        Book Add(Book book);
        Book Update(Book book);
        void Remove(Book book);

        BookWithCount GetAllByFilterType(BookFilterModel bookFilterModel);
        BookWithCount GetAllByFilterAZ(BookFilterModel bookFilterModel);
        BookWithCount GetAllByFilterZA(BookFilterModel bookFilterModel);
        BookWithCount GetAllByFilterPriceUpToDown(BookFilterModel bookFilterModel);
        BookWithCount GetAllByFilterPriceDownToUp(BookFilterModel bookFilterModel);
    }
}
