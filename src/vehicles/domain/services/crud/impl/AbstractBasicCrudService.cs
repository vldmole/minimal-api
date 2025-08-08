using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.src.vehicles.domain.services.crud.impl
{
    public class AbstractBasicCrudService<TEntity, TContext>(TContext dbContext) : IBasicCrudService<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _dbContext = dbContext;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var newVehicleEntry = await _dbContext.AddAsync<TEntity>( entity);
            return newVehicleEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Remove<TEntity>(entity);
        }

        public ValueTask<TEntity?> FindByIdAsync(int id)
        {
            return _dbContext.FindAsync<TEntity>(id);
        }

        public  async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate, int page=0, int pageSize=20)
        {
            return await _dbContext.Set<TEntity>()
                .AsQueryable()
                .Where(predicate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }

        public void UpdateAsync(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);
        }
    }
}