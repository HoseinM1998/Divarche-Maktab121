using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Divarcheh.Endpoints.RazorPages
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

        public static string GetUserId(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }
    }
}
