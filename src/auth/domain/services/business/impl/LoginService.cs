using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using minimal_api.src.auth.domain.entities;
using minimal_api.src.auth.domain.services.business;
using minimal_api.src.auth.domain.services.crud;
using minimal_api.src.auth.infraestructure.database;

namespace minimal_api.auth
{
    public class LoginService(AuthDbContext dbContext) : ILoginService
    {
        private readonly AuthDbContext _dbContext = dbContext;

 /*       public static string login(LoginDTO loginDto)
        {
            Console.WriteLine(loginDto.Email);
            Console.WriteLine(loginDto.Password);

            if (!(loginDto.Email.Equals("vldm@myCompany.com") && loginDto.Password.Equals("1234")))
                throw new Exception("Invalid login information");

            string token = "xywz";
            return token;
        }
*/
        public string Login(LoginDTO loginDTO)
        {
            IQueryable<Administrator> dbSet = _dbContext.Administrators.Where<Administrator>(
                entity => (entity.Email.Equals(loginDTO.Email) && entity.Password.Equals(loginDTO.Password))
            );
            if (!dbSet.Any())
                throw new Exception("Invalid user or password");

            string token = "xywz";//for example only
            return token;
        }
    }
}