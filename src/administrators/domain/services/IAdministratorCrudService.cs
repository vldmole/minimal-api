using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.dtos;
using minimal_api.src.common.domain.services.crud.impl;


namespace minimal_api.src.administrators.domain.services.crud
{
    public interface IAdministratorCrudService : IBasicCrudService<Administrator>
    {
        Administrator Create(AdministratorDTO dto);
        Administrator Update(int id, AdministratorDTO dto);
    }
}