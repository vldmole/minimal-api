using Microsoft.AspNetCore.Mvc;
using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.domain.services.crud;
using minimal_api.src.administrators.dtos;
using minimal_api.src.api;

namespace minimal_api.src.administrators.api
{
    public class AdministratorApiMapper : IEndpointMapper
    {
        static readonly string URL_BASE = "/administrator";
        public static void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler
        {
            app.MapPost(URL_BASE,
                static ([FromBody] AdministratorDTO dto, IAdministratorCrudService service) =>
                {
                    var newDto = service.Create(dto);
                    return Results.Created($"{URL_BASE}/{newDto.Id}", newDto);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Administrators");

            app.MapPut($"{URL_BASE}/{{id}}",
                static ([FromRoute] int id, [FromBody] AdministratorDTO dto, IAdministratorCrudService service) =>
                {
                    Administrator newAdm = service.Update(id, dto);
                    return Results.Created($"{URL_BASE}/{newAdm.Id}", newAdm);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Administrators");

            app.MapDelete($"{URL_BASE}/{{id}}",
                static ([FromRoute] int id, IAdministratorCrudService service)=>
                {
                    service.Delete(id);
                    return Results.Ok();
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Administrators");


            app.MapGet($"{URL_BASE}/{{id}}",
                static ([FromRoute] int id, IAdministratorCrudService service) =>
                {
                    return service.FindById(id);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Administrators");

            app.MapGet(URL_BASE,
                static (IAdministratorCrudService service, [FromQuery] int page=0, [FromQuery] int pageSize=20) =>
                {
                    var list = service.ReadAll((v) => true, page, pageSize);
                    return Results.Ok(list);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Administrators");
        }
    }
}