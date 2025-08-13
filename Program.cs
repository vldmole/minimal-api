using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
    })
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
    
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AuthDbContext>();
builder.Services.AddDbContext<VehicleDbContext>();
builder.Services.AddDbContext<AdministratorDbContext>();

builder.Services.AddScoped<IAdministratorCrudService, AdministratorCrudService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IVehicleCrudService, VehicleCrudService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Put JWT token here: {token}"
        }
    );
/*
    var securityRequirement = new OpenApiSecurityRequirement();
    securityRequirement.Add(
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        []
    );
    options.AddSecurityRequirement(securityRequirement);
    //it is the same as following  
*/
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});
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
