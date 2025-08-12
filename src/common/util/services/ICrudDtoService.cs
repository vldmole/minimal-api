using minimal_api.src.common.domain.services.crud.impl;

namespace minimal_api.src.common.util.services
{
    public interface ICrudDtoService<TDto, TEntity> : IBasicCrudService<TEntity>
        where TDto : class
        where TEntity : class
    {
        TDto Create(TDto dto);
    }
}