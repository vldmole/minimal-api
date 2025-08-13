using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualBasic;
using minimal_api.auth;
using minimal_api.src.api;

using minimal_api.src.auth.domain.services.business;



namespace minimal_api.api.auth
{
    public class AuthApiMapper : IEndpointMapper
    {
        public static void MapEndpoints<TExceptionHandler>(WebApplication app) where TExceptionHandler : IEndpointExcpetionHandler
        {
            app.MapPost("/login",
                        static ([FromBody] LoginDTO loginDTO, ILoginService service) =>
                            TypedResults.Ok(service.Login(loginDTO))    
                )
                .AddEndpointFilter<TExceptionHandler>()
                .WithTags("Auth");
        }
    }
}