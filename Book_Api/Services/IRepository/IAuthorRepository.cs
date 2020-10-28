using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Services.IRepository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors(int skip , int bookTypeId, List<int?> publisherIdList = null);
        Task<IEnumerable<Author>> GetAllAuthors();
    }
}
