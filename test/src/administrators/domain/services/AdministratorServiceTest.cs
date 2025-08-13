using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.domain.services.crud;

namespace test.src.administrators.domain.services
{
    [TestClass]
    public class AdministratorServiceTest
    {

        [TestMethod]
        public void shouldPersistAdministrator()
        {
            //Arrange
            var entity = new Administrator()
            {
                Email = "email@company.com",
                Password = "password",
                Perfil = "perfil"
            };
                

            //Act

            //Assert
        }
    }
}