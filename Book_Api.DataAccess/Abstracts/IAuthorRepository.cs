using Book_Api.Core.DataAccess;
using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.DataAccess.Abstracts
{
    public interface IAuthorRepository : IEntityRepository<Author>
    {
        List<Author> GetAllByTypeAndPublisher(int skip, int bookTypeId, List<int?> publisherIdList = null);
        List<Author> GetAuthorsByNameTextSearch(string search); 
    }
}
