using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimal_api.src.api;
using minimal_api.src.common.util.services;
using minimal_api.src.vehicles.domain.services.crud.impl;

namespace minimal_api.src.common.util.api
{
    
    public class AbstractEndpointCrudMapper<TDto, TEntity, TService>(string endpointBase): ICrudEndpointsMapper
        where TDto : class
        where TEntity : class
        where TService : ICrudDtoService<TDto,TEntity>
    {
        public void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler
        {
            app.MapPost(endpointBase,
                ([FromBody] TDto dto, TService service) =>
                {
                    TDto newDto = service.Create(dto);
                    return Results.Created($"{endpointBase}/{{id}}", newDto);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");
        }
    }
}