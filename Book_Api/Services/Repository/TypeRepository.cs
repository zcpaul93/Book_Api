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
    public class TypeRepository : ITypeRepository
    {
        readonly BookDbContext _context;
        public TypeRepository(BookDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Types>> GetTypes()
        {
            var types = await _context.Types.ToListAsync();

            return types;
        }
    }
}
