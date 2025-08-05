using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace minimal_api.auth
{
    public class LoginDTO
    {
        public string Email { get; }
        public string Password { get;  }

        public LoginDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}