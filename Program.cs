using Microsoft.EntityFrameworkCore;
using minimal_api.api.auth;
using minimal_api.auth;
using minimal_api.src.auth.domain.services.business;
using minimal_api.src.auth.infraestructure.database;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.infraestructure.database;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

ApiMapper.mapEndpoints(app);

app.Run();
