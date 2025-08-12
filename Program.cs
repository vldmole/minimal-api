using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.api.auth;
using minimal_api.auth;
using minimal_api.src.api;
using minimal_api.src.auth.domain.services.business;
using minimal_api.src.auth.domain.services.crud;
using minimal_api.src.auth.domain.services.crud.impl;
using minimal_api.src.auth.infraestructure.database;
using minimal_api.src.home.modelViews;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.api;
using minimal_api.src.vehicles.domain.services.crud;
using minimal_api.src.vehicles.domain.services.crud.impl;
using minimal_api.src.vehicles.infraestructure.database;

var builder = WebApplication.CreateBuilder(args);

#region configuringServices
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    if (options.IsConfigured)
    {
        Console.WriteLine("Database connection already configured");
        return;
    }

    string? connectionString = builder.Configuration.GetConnectionString("mysql");
    if (string.IsNullOrEmpty(connectionString))
        throw new Exception($"Connection String could not be null {connectionString}");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddDbContext<VehicleDbContext>();

builder.Services.AddScoped<IAdministratorCrudService, AdministratorService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IVehicleCrudService, VehicleCrudService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

#region mappingEdnpoints

app.MapGet("/", () => Results.Json(new Home()));

//GlobalEndpointExceptionHandler globalExceptionHandler = new GlobalEndpointExceptionHandler();

AuthApiMapper.MapEndpoints<GlobalEndpointExceptionHandler>(app);
VehiclesApiMapper.MapEndpoints<GlobalEndpointExceptionHandler>(app); 

#endregion

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
