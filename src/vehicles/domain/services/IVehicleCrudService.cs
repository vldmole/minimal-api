using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.domain.services.crud.impl;
using minimal_api.src.vehicles.dtos;

namespace minimal_api.src.vehicles.domain.services.crud
{
    public interface IVehicleCrudService : IBasicCrudService<Vehicle>
    {
        Vehicle Create(VehicleDTO vehicleDTO);
        Vehicle Update(int id, VehicleDTO vehicleDTO);
    }
}