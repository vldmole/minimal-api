using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace minimal_api.src.vehicle.domain.entities
{
    public class Vehicle : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Brand { get; set; } = default!;

        [Required]
        public int Year { get; set; } = default!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errorList = [];

            Vehicle vehicle = (Vehicle)validationContext.ObjectInstance;
            
            if (vehicle.Year < 1900)
                errorList.Add(new ValidationResult($"Attribute 'Year' (value: {vehicle.Year}) needs to be greater than 1900"
                                                   , ["Year"]));

            return errorList;
        }
    }
}