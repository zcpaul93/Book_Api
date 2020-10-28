using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book_Api_Service.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
    }
}
