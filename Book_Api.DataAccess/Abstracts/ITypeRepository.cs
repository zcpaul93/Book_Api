using Book_Api.Core.DataAccess;
using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.DataAccess.Abstracts
{
    public interface ITypeRepository : IEntityRepository<Types>
    {
    }
}
