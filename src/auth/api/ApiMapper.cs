using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using minimal_api.auth;

namespace minimal_api.api.auth
{
    public class ApiMapper
    {
        static public
        void mapEndpoints(WebApplication app)
        {
            app.MapGet("/", () => "c# Minimal-API");
            app.MapPost("/login", CreateDelegateHandler<LoginDTO>(LoginService.login));
        }

        internal static Delegate CreateDelegateHandler<T>(Delegate method)
        {
            return (T param) =>
            {
                try
                {
                    return Results.Ok(method.DynamicInvoke(param));
                }
                catch (Exception)
                {
                    return  Results.Unauthorized();
                }
            };
        }
    }
}