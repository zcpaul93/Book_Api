using Book_Api.Data;
using Book_Api.Data.Models;
using Book_Api_Service.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book_Api_Service.Repository
{
    public class BookRepository : IBookRepository
    {
        readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
