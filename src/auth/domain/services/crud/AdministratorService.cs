using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.src.auth.domain.entities;
using minimal_api.src.auth.infraestructure.database;
using minimal_api.src.vehicles.domain.services.crud.impl;

namespace minimal_api.src.auth.domain.services.crud.impl
{
    public class AdministratorService (AuthDbContext dbContext) :
        AbstractBasicCrudService<Administrator, AuthDbContext>(dbContext),
        IAdministratorCrudService
    {
    }
}