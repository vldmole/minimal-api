using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.auth;
using minimal_api.src.vehicles.domain.services.crud.impl;

namespace minimal_api.src.auth.domain.services.business
{
    public interface ILoginService
    {
        public string Login(LoginDTO loginDTO);
    }
}