using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml;

namespace Authorization
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        
        /// <summary>
        /// Checks if the principal specified in the authorization context is authorized to perform action specified in the authorization context 
        /// on the specified resoure
        /// </summary>
        /// <param name="pec">Authorization context: Provides context information of an authorization event. (Principal,Resource,Action)</param>
        /// <returns>true if authorized, false otherwise</returns>
        public override bool CheckAccess(AuthorizationContext pec)
        {
            var claim = pec.Action.First().Value + " " + pec.Resource.First().Value;
            bool access;
            
            try
            {
                access = pec.Principal.HasClaim(claim,"True");
                access = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nMessage ---\n{0}", e.Message); ;
                access = false;
            }
            return access;
        }
    }
}
