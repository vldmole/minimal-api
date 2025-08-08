using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.vehicle.domain.entities
{
    public class Vehicle
    {
        public Vehicle(int id, string name, string brand, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Brand = brand;
            this.Year = year;
        }

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
    }
}