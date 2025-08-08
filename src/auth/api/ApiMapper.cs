using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualBasic;
using minimal_api.auth;
using minimal_api.src.auth.domain.services.business;
using minimal_api.src.home.modelViews;

namespace minimal_api.api.auth
{
    public class ApiMapper
    {
        static public
        void mapEndpoints(WebApplication app)
        {
            
    
            app.MapPost("/login",
                        static ([FromBody] LoginDTO loginDTO, ILoginService service)
                            => Results.Ok($"token : {service.Login(loginDTO)}")
                ).AddEndpointFilter<ExceptionFilter>();
        }

        internal class ExceptionFilter : IEndpointFilter
        {
            public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
            {
                try
                {
                    // Execute the next filter in the pipeline or the endpoint handler
                    return await next(context);
                }
                catch (Exception ex)
                {
                    // Custom exception handling logic
                    // You can log the exception, return a specific error response, etc.
                    Console.WriteLine($"ExceptionFilter: An error occurred: {ex.Message}");

                    // Return a ProblemDetails or a custom error object
                    return Results.Problem(
                        statusCode: StatusCodes.Status401Unauthorized,
                        title: "Invalid Data",
                        detail: ex.Message
                    );
                }
            }
        }
    }
}