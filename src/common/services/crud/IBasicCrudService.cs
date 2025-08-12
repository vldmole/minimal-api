using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace minimal_api.src.vehicles.domain.services.crud.impl
{
    public interface IBasicCrudService<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);

        List<TEntity> ReadAll(Expression<Func<TEntity, bool>> predicate, int page, int pageSize );
        TEntity FindById(int id);

        void SaveChanges();
        void SaveChangesAsync();

    }
}