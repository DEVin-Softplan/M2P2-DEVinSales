using DevInSales.Models;
using DevInSales.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Test.utils
{
    public class TokenGenerator
    {
        public static string GenerateToken(EProfileType tokenType)
        {
            var profile = new Profile() { Type = tokenType };
            var user = new User()
            {
                Id = 1,
                Name = "Testes",
                Profile = profile,
            };
            return new TokenService().GenerateToken(user);
        }
    }
}
