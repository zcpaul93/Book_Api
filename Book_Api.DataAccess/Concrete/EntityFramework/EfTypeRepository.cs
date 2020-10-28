using Book_Api.Core.DataAccess.EntityFramework;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.DataAccess.Concrete.EntityFramework
{
    public class EfTypeRepository : EfEntityRepositoryBase<Types>, ITypeRepository
    {
        private readonly BookDbContext _context;
        public EfTypeRepository(BookDbContext context):base(context)
        {
            _context = context;
        }
    }
}
