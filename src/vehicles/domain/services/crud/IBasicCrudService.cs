using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace minimal_api.src.vehicles.domain.services.crud.impl
{
    public interface IBasicCrudService<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void Delete(TEntity entity);

        Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize );
        ValueTask<TEntity?> FindByIdAsync(int id);

        void SaveChanges();
        void SaveChangesAsync();

    }
}