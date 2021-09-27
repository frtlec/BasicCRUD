using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

   
        public static string ClaimUserName(this ClaimsPrincipal claimsPrincipal)
        {

            return claimsPrincipal != null ?
                        claimsPrincipal.Claims(ClaimTypes.Name).Count() > 0 ?

                         claimsPrincipal.Claims(ClaimTypes.Name).First()
                        : ""
                    : "";
        }
    }
}
