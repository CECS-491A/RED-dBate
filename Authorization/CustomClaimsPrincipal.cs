using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomClaimsPrincipal : ClaimsAuthenticationManager
    {
        /// <summary>
        /// 
        /// </summary>
        private ClaimStorage ClaimStorage = new ClaimStorage();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="incomingPrincipal"></param>
        /// <returns></returns>
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {

            var claimsCollection = (List<Claim>) incomingPrincipal.Claims;

            return CreatePrincipal(claimsCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimsCollection"></param>
        /// <returns></returns>
        private ClaimsPrincipal CreatePrincipal(List<Claim> claimsCollection)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(claimsCollection));
        }
    }
}
