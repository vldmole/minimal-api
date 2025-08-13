using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.src.common.domain.services.crud.impl
{
    public class AbstractBasicCrudService<TEntity, TContext>(TContext dbContext) : IBasicCrudService<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _dbContext = dbContext;

        public TEntity Create(TEntity entity)
        {
            var newEntry = _dbContext.Add( entity);
            return newEntry.Entity;
        }

        public virtual void Delete(int id)
        {
            var entity = _dbContext.Find<TEntity>(id) ?? throw new Exception($"Entity not found id:{id}");
            _dbContext.Remove(entity);
        }

        public TEntity FindById(int id)
        {
            return _dbContext.Find<TEntity>(id) ?? throw new Exception($"Entity not found id:{id}");
        }

        public List<TEntity> ReadAll(Expression<Func<TEntity, bool>> predicate, int page = 0, int pageSize = 20)
        {
            return _dbContext.Set<TEntity>()
                        .AsQueryable()
                        .Where(predicate)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            return _dbContext.Update(entity).Entity;
        }
    }
}