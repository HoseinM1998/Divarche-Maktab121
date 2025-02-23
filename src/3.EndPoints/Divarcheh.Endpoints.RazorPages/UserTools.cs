using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Divarcheh.Domain.Services
{
    public static class UserTools
    {
        public static string GetRole(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
        }
        public static string GetCityId(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "CityId").Value;
        }       
        public static string GetEmail(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "Email").Value;
        }

        public static string GetUserName(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "Username").Value;
        }
    }
}
