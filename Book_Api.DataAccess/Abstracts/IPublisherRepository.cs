using Book_Api.Core.DataAccess;
using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.DataAccess.Abstracts
{
    public interface IPublisherRepository : IEntityRepository<Publisher>
    {
        List<Publisher> GetAllByTypeAndAuthor(int skip, int bookTypeId, List<int?> authorIdList = null);
        List<Publisher> GetPublishersByNameTextSearch(string search);
    }
}
