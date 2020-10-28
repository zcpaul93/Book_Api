using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Book_Api.Services.IRepository
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetPublishers(int skip, int bookTypeId, List<int?> authorIdList = null);
        Task<IEnumerable<Publisher>> GetAllPublishers();
    }
}

