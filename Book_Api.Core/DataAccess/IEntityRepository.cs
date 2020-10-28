using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Book_Api.Core.DataAccess
{
    public interface IEntityRepository<T>
        where T:class, IEntity, new()
    {
        T Get(Expression<Func<T,bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllQuery(Expression<Func<T,bool>> filter=null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
