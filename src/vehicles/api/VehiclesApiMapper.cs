using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimal_api.src.api;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.domain.services.crud;
using minimal_api.src.vehicles.dtos;

namespace minimal_api.src.vehicles.api
{
    public class VehiclesApiMapper : IEndpointMapper
    {
        public static void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler
        {
            app.MapPost("/vehicle",
                static ([FromBody] VehicleDTO vehicleDTO, IVehicleCrudService service) =>
                {
                    var vehicle = service.Create(vehicleDTO);
                    return Results.Created($"/Vehicle/{vehicle.Id}", vehicle);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");


            app.MapPut("/vehicle/{id}",
                static ([FromRoute] int id, [FromBody] VehicleDTO vehicleDTO, IVehicleCrudService service) =>
                {
                    Vehicle vehicle = service.Update(id, vehicleDTO);
                    return Results.Created($"/Vehicle/{vehicle.Id}", vehicle);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");

            app.MapDelete("/vehicle/{id}",
                static ([FromRoute] int id, IVehicleCrudService service)=>
                {
                    service.Delete(id);
                    return Results.Ok();
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");


            app.MapGet("/vehicle/{id}",
                static ([FromRoute] int id, IVehicleCrudService service) =>
                {
                    return service.FindById(id);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");

            app.MapGet("/vehicle",
                static ([FromQuery] int page, [FromQuery] int pageSize, IVehicleCrudService service) =>
                {
                    var list = service.ReadAll((v) => true, page, pageSize);
                    return Results.Ok(list);
                })
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Vehicle");
        }
    }
}