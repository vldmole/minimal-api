using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.infraestructure.database;

namespace minimal_api.src.vehicles.domain.services.crud.impl
{
    public class VehicleCrudService (VehicleDbContext dbContext) 
        : AbstractBasicCrudService<Vehicle, VehicleDbContext>(dbContext),
          IVehicleCrudService
    {
        //nothing for while
    }
}