using Book_Api.Data;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Concrete.EntityFramework;
using Book_Api.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Services.Repository
{
    public class PublisherRepository : IPublisherRepository
    { 
        readonly BookDbContext _context;
        public PublisherRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetPublishers(int skip, int bookTypeId, List<int?> authorIdList = null)
        {
            if(authorIdList.Count == 0 || authorIdList[0] == null) 
            {
               var publishers = await _context.Publishers
                                .Where(p =>
                                _context.Books
                                    .Where(b =>
                                    _context.BookTypes
                                    .Where(bt => bt.TypesId == bookTypeId).Select(bt => bt.BookId).Contains(b.BookId))
                                       .Select(b => b.Publisher.Id).Contains(p.Id))
                                        .OrderBy(p => p.Name)
                                        .Skip(skip).Take(2).ToListAsync();

                return publishers;
            }
            else
            {
                return await FilterByAuthor(skip, bookTypeId, authorIdList);
            }


            
        }

        public async Task<IEnumerable<Publisher>> FilterByAuthor(int skip, int bookTypeId, List<int?> authorIdList) 
        {
            var publisherList = new List<Publisher>();

            foreach (var authorId in authorIdList)
            {
                var publishers = await _context.Publishers
                    .Where(p =>
                    _context.Books
                        .Where(b =>
                            _context.BookTypes
                            .Where(bt => bt.TypesId == bookTypeId).Select(bt => bt.BookId).Contains(b.BookId))
                        .Where(b => b.Author.Id == authorId)
                           .Select(b => b.Publisher.Id).Contains(p.Id))
                            .OrderBy(p => p.Name)
                            .ToListAsync();

             

                publisherList.AddRange(publishers);
            }

            return publisherList.OrderBy(p => p.Name);
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            return await _context
                .Publishers.ToListAsync();
        }
    }
}

