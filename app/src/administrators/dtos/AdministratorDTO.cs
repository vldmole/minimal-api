using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.src.administrators.dtos
{
    public class AdministratorDTO
    {
        public int? Id { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Perfil { get; set; }
    }
}