using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        List<Author> GetAllByTypeAndPublisher(int skip, int bookTypeId, List<int?> publisherIdList = null);
        List<Author> GetAuthorsByNameTextSearch(string search);
        Author Get(int Id);

        Author Add(Author author);
        Author Update(Author author);
    }
}
