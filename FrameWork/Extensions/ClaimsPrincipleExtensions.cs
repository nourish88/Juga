using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Framework.Extensions
{
    public static class ClaimsPrincipleExtensions
    {//claimin rolleri
        public static List<string> Claims(this ClaimsPrincipal claimsPrinciple, string claimType)
        {
            return claimsPrinciple.FindAll(claimType).Select(x => x.Value).ToList();
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrinciple)
        {
            return claimsPrinciple?.Claims(ClaimTypes.Role);
        }
    }
}
