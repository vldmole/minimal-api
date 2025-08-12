using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.common.modelViews
{
    public record ValidationError(params String[] Error)
    {
        public readonly List<String> ErrorList = [.. Error];
    }
}