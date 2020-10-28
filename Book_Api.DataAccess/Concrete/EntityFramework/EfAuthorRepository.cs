using Book_Api.Core.DataAccess.EntityFramework;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Book_Api.DataAccess.Concrete.EntityFramework
{
    public class EfAuthorRepository : EfEntityRepositoryBase<Author>, IAuthorRepository
    {
        private readonly BookDbContext _context;
        public EfAuthorRepository(BookDbContext context):base(context)
        {
            _context = context;
        }

        public List<Author> GetAllByTypeAndPublisher(int skip, int bookTypeId, 
            List<int?> publisherIdList = null)
        {
            var query = (from a in _context.Authors
                          join b in _context.Books on a.Id equals b.AuthorId
                          join bt in _context.BookTypes on b.BookId equals bt.BookId
                          join t in _context.Types on bt.TypesId equals t.TypesId
                          join p in _context.Publishers on b.PublisherId equals p.Id
                          where t.TypesId == bookTypeId &&
                                (publisherIdList.Count > 0
                                  ? publisherIdList.Contains(p.Id)  
                                  : p.Id == p.Id)
                          select a);

            
            var takeAuthor = 8;
            var authors = query.Distinct().OrderBy(x => x.Name).Skip(skip * takeAuthor).Take(takeAuthor).ToList();

            return authors;
        }

        public List<Author> GetAuthorsByNameTextSearch(string search)
        {
            var authors = _context.Authors
                .Where(a => a.Name.Contains(search))
                .ToList();

            return authors;
        }
    }
}
