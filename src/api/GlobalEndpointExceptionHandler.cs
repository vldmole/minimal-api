using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace minimal_api.src.api
{
    public class GlobalEndpointExceptionHandler : IEndpointExcpetionHandler
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
                
                List<KeyValuePair<string, Object?>> errors = [];
                foreach (DictionaryEntry error in ex.Data)
                    errors.Add(new($"{error.Key}", error.Value));
                    
                // Return a ProblemDetails or a custom error object
                return Results.Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "Invalid Data",
                    detail: ex.Message,
                    extensions: errors
                );
            }
        }
    }
}