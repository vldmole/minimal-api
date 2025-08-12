using System.ComponentModel.DataAnnotations;
using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.dtos;
using minimal_api.src.administrators.infraestructure.database;
using minimal_api.src.common.domain.services.crud.impl;


namespace minimal_api.src.administrators.domain.services.crud.impl
{
    public class AdministratorCrudService(AdministratorDbContext dbContext) :
        AbstractBasicCrudService<Administrator, AdministratorDbContext>(dbContext),
        IAdministratorCrudService
    {
        public Administrator Create(AdministratorDTO AdministratorDTO)
        {
            Administrator newAdministrator = FromDto(AdministratorDTO);

            List<ValidationResult> errors = [];
            bool isValid = Validator.TryValidateObject(newAdministrator, new ValidationContext(newAdministrator), errors, true);

            if (!isValid)
            {
                var exception = new Exception("Validation Error!");
                exception.Data.Add("errors", errors);

                throw exception;
            }

            newAdministrator = base.Create(newAdministrator);
            base.SaveChanges();

            return newAdministrator;
        }

        public Administrator Update(int id, AdministratorDTO AdministratorDTO)
        {
            Administrator Administrator = FromDto(AdministratorDTO);
            Administrator.Id = id;
                
            var updated = base.Update(Administrator);
            base.SaveChanges();

            return updated;
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            base.SaveChanges();
        }

        internal static Administrator FromDto(AdministratorDTO dto)
        {
            return new()
            {
                Id = dto.Id ?? -1,
                Email = dto.Email ?? "",
                Password = dto.Password ?? "",
                Perfil = dto.Perfil ?? ""
            };
        }
    }
}