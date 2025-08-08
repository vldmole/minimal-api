using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.home.modelViews
{
    public struct Home
    {
        public readonly string message { get => "Using dotNet Minimal-api"; }
        public readonly string Documentation { get => "/swagger"; }
    }
}