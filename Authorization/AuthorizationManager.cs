using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class AuthorizationManager
    {
        static Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>> _policies = new Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>>();
        //PolicyReader _policyReader = new PolicyReader();

        /// <summary>
        /// Checks if the principal specified in the authorization context is authorized to perform action specified in the authorization context 
        /// on the specified resoure
        /// </summary>
        /// <param name="pec">Authorization context: Provides context information of an authorization event. (Principal,Resource,Action)</param>
        /// <returns>true if authorized, false otherwise</returns>
        public bool CheckAccess(AuthorizationContext pec)
        {
            bool access = true;
            try
            {
                ResourceAction ra = new ResourceAction(pec.Resource.First<Claim>().Value, pec.Action.First<Claim>().Value);
                access = _policies[ra](pec.Principal);

                // Return true or false determining user access
                return access;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nMessage ---\n{0}", e.Message); ;
                return access = false;
            }
        }
    }
}
