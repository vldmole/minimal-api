using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using minimal_api.src.administrators.domain.entities;
using minimal_api.src.administrators.domain.services.crud;
using minimal_api.src.auth.api.modelViews;
using minimal_api.src.auth.domain.services.business;

namespace minimal_api.auth
{
    public class LoginService(IConfiguration configuration, IAdministratorCrudService service) : ILoginService
    {
        public LoggedUser Login(LoginDTO loginDTO)
        {
            Expression<Func<Administrator, bool>> predicate = entity =>
                entity.Email.Equals(loginDTO.Email) && entity.Password.Equals(loginDTO.Password);

            var results = service.ReadAll(predicate);

            if (results.Count != 1)
                throw new Exception("Invalid user or password");

            var user = results.First();
            string token = GenerateJwtToken(user);

            return new LoggedUser(user.Email, user.Perfil, token);
        }

        readonly string JWT_KEY = configuration.GetSection("Jwt")
            .GetValue<string>("key") ?? throw new Exception("Invalid JWT_KEY");

        private string GenerateJwtToken(Administrator administrator)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_KEY));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new("Email", administrator.Email),
                new("Perfil", administrator.Perfil),
                new(ClaimTypes.Role, administrator.Perfil)
            };
            
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}