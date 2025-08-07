using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.auth;

namespace minimal_api.src.auth.domain.services.business
{
    public interface ILoginService
    {
        public string Login(LoginDTO loginDTO);
    }
}