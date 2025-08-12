using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using minimal_api.api.auth;
using minimal_api.auth;
using minimal_api.src.administrators.api;
using minimal_api.src.administrators.domain.services.crud;
using minimal_api.src.administrators.domain.services.crud.impl;
using minimal_api.src.administrators.infraestructure.database;
using minimal_api.src.api;
using minimal_api.src.auth.domain.services.business;
using minimal_api.src.auth.infraestructure.database;
using minimal_api.src.home.modelViews;
using minimal_api.src.vehicles.api;
using minimal_api.src.vehicles.domain.services.crud;
using minimal_api.src.vehicles.domain.services.crud.impl;
using minimal_api.src.vehicles.infraestructure.database;

var builder = WebApplication.CreateBuilder(args);

#region configuringServices

var jwtKey = builder.Configuration.GetSection("Jwt")["key"] ?? "1234567890";

builder.Services
    .AddAuthentication(static option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    ).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            };
        }
    );
    
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AuthDbContext>();
builder.Services.AddDbContext<VehicleDbContext>();
builder.Services.AddDbContext<AdministratorDbContext>();

builder.Services.AddScoped<IAdministratorCrudService, AdministratorCrudService>();
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
AdministratorApiMapper.MapEndpoints<GlobalEndpointExceptionHandler>(app);

#endregion

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
