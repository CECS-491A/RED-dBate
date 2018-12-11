using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Authorization
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

        public Client client = new Client();

        /// <summary>
        /// Method that checks whether a specific user is authorized for something
        /// </summary>
        /// <param name="claim">contains claim that is going to be checked for authorization</param>
        /// <returns></returns>
        public bool CheckAccess(Claim claim)
        {
            bool access;

            try
            {
                if(user.CollectionClaims.Contains(claim))
                {
                    access = true;
                }
                else if(client.ClaimCollection.Contains(claim) && user.CollectionClaims.Contains(claim)){
                    access = true;
                }
                else
                {
                    access = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return access;
        }
    }
}
