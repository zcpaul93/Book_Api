using Book_Api.Core.DataAccess.EntityFramework;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Book_Api.DataAccess.Concrete.EntityFramework
{
    public class EfPublisherRepository : EfEntityRepositoryBase<Publisher>, IPublisherRepository
    {
        private readonly BookDbContext _context;
        public EfPublisherRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Publisher> GetAllByTypeAndAuthor(int skip, int bookTypeId
            , List<int?> authorIdList = null)
        {
            var query = from p in _context.Publishers
                        join b in _context.Books on p.Id equals b.PublisherId
                        join bt in _context.BookTypes on b.BookId equals bt.BookId
                        join t in _context.Types on bt.TypesId equals t.TypesId
                        join a in _context.Authors on b.AuthorId equals a.Id
                        where t.TypesId == bookTypeId &&
                                (authorIdList.Count > 0
                                  ? authorIdList.Contains(a.Id)
                                  : a.Id == a.Id )
                        select p;

            var takeAuthor = 8;
            var publishers = query.Distinct().OrderBy(x => x.Name).Skip(skip * takeAuthor).Take(takeAuthor).ToList();

            return publishers;
        }

        public List<Publisher> GetPublishersByNameTextSearch(string search)
        {
            var publishers = _context.Publishers
                .Where(a => a.Name.Contains(search))
                .ToList();

            return publishers;
        }
    }
}
