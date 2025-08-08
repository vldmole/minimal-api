using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.domain.services.crud.impl;

namespace minimal_api.src.vehicles.domain.services.crud
{
    public interface IVehicleCrudService : IBasicCrudService<Vehicle>
    {
        
    }
}