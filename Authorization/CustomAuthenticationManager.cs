using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class CustomAuthenticationManager : ClaimsAuthenticationManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName">contains </param>
        /// <param name="incomingPrincipal">contains collection of claims</param>
        /// <returns></returns>
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            /*if (incomingPrincipal != null && incomingPrincipal.Identity.IsAuthenticated == true)
            {
                ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, "User"));
            }

            return incomingPrincipal;*/
            throw new NotImplementedException();
        }
    }
}
