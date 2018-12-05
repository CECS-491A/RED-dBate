using ModelLayer;
using System;

namespace Authorization
{
    /// <summary>
    /// Authorization management class
    /// </summary>
    public class AuthorizationManager
    {
        /// <summary>
        /// User Object that contains information of the specific user
        /// </summary>
        public User user = new User();

        //MIGHT HAVE TO FIX AUTHORIZATION MANAGER TO HAVE ALL 3 TYPE CHECKS
        /// <summary>
        /// Method that checks whether a specific user is authoried for somethig
        /// </summary>
        /// <param name="claim">contains claim that is going to be checked for authorization</param>
        /// <returns></returns>
        public bool CheckAccess(string claim)
        {
            bool access;

            try
            {
                if (user.CollectionClaims.Contains(claim))
                {
                    access = true;
                }
                else
                {
                    access = false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return access;
        }
    }
}
