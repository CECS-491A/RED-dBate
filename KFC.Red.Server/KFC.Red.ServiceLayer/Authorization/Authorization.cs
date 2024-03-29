﻿using KFC.Red.DataAccessLayer;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace KFC.Red.ServiceLayer.Authorization
{
    /// <summary>
    /// Authorization management class
    /// </summary>
    public class Authorization : IAuthorize
    {
        /// <summary>
        /// User Object that contains information of the specific user
        /// </summary>
        public User user = new User();

        //public Client client = new Client();

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
                else
                {
                    access = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Not Authorized" );
                return false;
            }

            return access;
        }
    }
}
