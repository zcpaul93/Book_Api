using Book_Api.Data;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Concrete.EntityFramework;
using Book_Api.Services.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Services.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly BookDbContext _context;
        public AuthorRepository(BookDbContext context)
        {
            _context = context;
        }

    

        public async Task<IEnumerable<Author>> GetAuthors(int skip , int bookTypeId, List<int?> publisherIdList = null)
        {
            //var sql = @"Select * from Authors Where Id in 
            //                (Select AuthorId from Books Where BookId in 
            //                (Select BookId from BookTypes Where TypesId = 5)) 
            //                   order by Name asc offset 2 rows fetch next 1 rows only";


            //stored procedure
            //var authors = await _context.Authors.FromSqlRaw($"GetAuthors {5},{0}").ToListAsync();

            if (publisherIdList.Count == 0 || publisherIdList[0] == null)
            {
                var authors = await _context.Authors
                .Where(a =>
                _context.Books
                    .Where(b =>
                    _context.BookTypes
                    .Where(bt => bt.TypesId == bookTypeId).Select(bt => bt.BookId).Contains(b.BookId))
                       .Select(b => b.Author.Id).Contains(a.Id))
                        .OrderBy(a => a.Name)
                        .Skip(skip).Take(2).ToListAsync();

                return authors;
            }
            else 
            {
                return await FilterByPublisher(skip, bookTypeId, publisherIdList);
            }

 
            
        }

        public async Task<IEnumerable<Author>> FilterByPublisher(int skip, int bookTypeId, List<int?> publisherIdList)
        {
            var authorList = new List<Author>();

            foreach (var publisherId in publisherIdList)
            {
                var authors = await _context.Authors
                                .Where(a =>
                                _context.Books
                                    .Where(b =>
                                        _context.BookTypes
                                        .Where(bt => bt.TypesId == bookTypeId).Select(bt => bt.BookId).Contains(b.BookId))
                                    .Where(b => b.Publisher.Id == publisherId)
                                       .Select(b => b.Author.Id).Contains(a.Id))
                                        .OrderBy(a => a.Name)
                                        .ToListAsync();
 
                    foreach (var author in authors)
                    {
                        if(!authorList.Any(al => al.Id == author.Id)) 
                        {
                            authorList.AddRange(authors);
                        }
                    }
              
            }

            return authorList.OrderBy(p => p.Name);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _context
                .Authors.ToListAsync();
        }

    }
}
