using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.auth.domain.entities
{
    public class Administrator
    {
        public Administrator(int id, string email, string password, string perfil)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Perfil = perfil;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = default!;

        [Required]
        [StringLength(10)]
        public string Perfil { get; set; } = default!;
    }
}