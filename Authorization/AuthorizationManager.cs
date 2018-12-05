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
        /// 
        /// </summary>
        public User user = new User();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
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
