using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Business.Abstract
{
    public interface IPublisherService
    {
        List<Publisher> GetAll();
        List<Publisher> GetAllByTypeAndAuthor(int skip, int bookTypeId, List<int?> authorIdList = null);
        List<Publisher> GetPublishersByNameTextSearch(string search);
        Publisher Get(int Id);

        Publisher Add(Publisher publisher);
        Publisher Update(Publisher publisher);
    }
}
