using System.ComponentModel.DataAnnotations;
using minimal_api.src.common.domain.services.crud.impl;
using minimal_api.src.vehicle.domain.entities;
using minimal_api.src.vehicles.dtos;
using minimal_api.src.vehicles.infraestructure.database;

namespace minimal_api.src.vehicles.domain.services.crud.impl
{
    public class VehicleCrudService(VehicleDbContext dbContext)
        : AbstractBasicCrudService<Vehicle, VehicleDbContext>(dbContext),
          IVehicleCrudService
    {
        public Vehicle Create(VehicleDTO vehicleDTO)
        {
            Vehicle newVehicle = FromDto(vehicleDTO);

            List<ValidationResult> errors = [];
            bool isValid = Validator.TryValidateObject(newVehicle, new ValidationContext(newVehicle), errors, true);

            if (!isValid)
            {
                var exception = new Exception("Validation Error!");
                exception.Data.Add("errors", errors);

                throw exception;
            }

            newVehicle = base.Create(newVehicle);
            base.SaveChanges();

            return newVehicle;
        }

        public Vehicle Update(int id, VehicleDTO vehicleDTO)
        {
            Vehicle vehicle = FromDto(vehicleDTO);
            vehicle.Id = id;
                
            var updated = base.Update(vehicle);
            base.SaveChanges();

            return updated;
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            base.SaveChanges();
        }

        internal static Vehicle FromDto(VehicleDTO vehicleDTO)
        {
            return new()
            {
                Id = vehicleDTO.Id,
                Name = vehicleDTO.Name,
                Brand = vehicleDTO.Brand,
                Year = vehicleDTO.Year
            };
        }
    }
}