using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.auth
{
    public class LoginService
    {
        public static string login(LoginDTO loginDto)
        {
            Console.WriteLine(loginDto.Email);
            Console.WriteLine(loginDto.Password);

            if (!(loginDto.Email.Equals("vldm@myCompany.com") && loginDto.Password.Equals("1234")))
                throw new Exception("Invalid login information");

            string token = "xywz";
            return token;
        }
    }
}