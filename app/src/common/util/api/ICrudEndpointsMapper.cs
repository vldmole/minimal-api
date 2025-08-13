using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.src.api;

namespace minimal_api.src.common.util.api
{
    public interface ICrudEndpointsMapper
    {
        abstract void MapEndpoints<TExceptionHandler>(WebApplication app)
            where TExceptionHandler : IEndpointExcpetionHandler;
    }
}