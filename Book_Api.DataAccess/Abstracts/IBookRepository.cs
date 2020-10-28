using Book_Api.Core.DataAccess;
using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Book_Api.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Book_Api.DataAccess.Abstracts
{
    public interface IBookRepository : IEntityRepository<Book> 
    {
        Book GetBookWithAuthorPublisher(Expression<Func<Book,bool>> filter);
        List<Book> GetBooksWithFilter(Expression<Func<Book, bool>> filter);
        BookWithCount GetAllByFilterOrderBy(BookFilterModel bookFilterModel,Expression<Func<Book, dynamic>> filter = null);
        BookWithCount GetAllByFilterOrderByDesc(BookFilterModel bookFilterModel, Expression<Func<Book, dynamic>> filter = null);
    }
}
