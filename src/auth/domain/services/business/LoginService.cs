using System.Linq.Expressions;
using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.domain.services.crud;
using minimal_api.src.auth.domain.services.business;

namespace minimal_api.auth
{
    public class LoginService(IAdministratorCrudService service) : ILoginService
    {
     //   private readonly AuthDbContext _dbContext = dbContext;

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
            Expression<Func<Administrator, bool>> predicate = entity => entity.Email.Equals(loginDTO.Email) && entity.Password.Equals(loginDTO.Password);
            var results = service.ReadAll(predicate, 0, 1);

            if (results.Count == 0)
                throw new Exception("Invalid user or password");

            string token = "xywz";//for example only
            return token;
        }
    }
}