using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.src.auth.domain.entities;
using minimal_api.src.auth.infraestructure.database;

namespace minimal_api.src.auth.domain.services.crud.impl
{
    public class AdministratorService (AuthDbContext dbContext): IAdministratorCrudService
    {
        private readonly AuthDbContext _dbContext = dbContext;
    
        public Administrator Create(Administrator entity)
        {
            throw new NotImplementedException();
        }

        public Administrator FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrator> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Administrator> GetAll(Predicate<Administrator> predicate)
        {
            return _dbContext.Administrators
                            .Where<Administrator>(entity => predicate.Invoke(entity));
        }

    }
}