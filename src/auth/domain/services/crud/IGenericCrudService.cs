using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.auth.domain.services.crud
{
    public interface IGenericCrudService<TEntity>
    {
        TEntity Create(TEntity entity);
        
        TEntity FindById(int id);
        List<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Predicate<TEntity> predicate);
    }
}