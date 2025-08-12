using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.api
{
    public interface IEndpointMapper
    {
        public static
        abstract void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler;
    }
}