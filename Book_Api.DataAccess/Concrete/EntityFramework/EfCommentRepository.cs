using Book_Api.Core.DataAccess.EntityFramework;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.DataAccess.Concrete.EntityFramework
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        private readonly BookDbContext _context;
        public EfCommentRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
