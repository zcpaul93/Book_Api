using Book_Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Book_Api.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
    {
        private readonly DbContext _context;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>()
                .SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var books = filter != null
                ? _context.Set<TEntity>().Where(filter).ToList()
                : _context.Set<TEntity>().ToList();

            return books;
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> filter = null)
        {
            var books = filter != null
                ? _context.Set<TEntity>().Where(filter)
                : _context.Set<TEntity>();

            return books;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
