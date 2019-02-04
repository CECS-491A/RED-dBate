using DataAccessLayer;
using DataAccessLayer.Models;
using ServiceLayer.Constants;
using ServiceLayer.UserManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserManagement
{
    /// <summary>
    /// Enables or disables account of a user
    /// </summary>
    public class Activation : Roles, IEnable
    {
        /// <summary>
        /// interface class that keeps track of data by having classes that can get repositories and saving it
        /// </summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// IRepository class, containins method used to add,delete, configure accounts/info
        /// </summary>
        private IRepository<User> _User;

        /// <summary>
        /// Contructor for Class initiates uow(unit of work) and user repository
        /// </summary>
        /// <param name="uow">interface class that keeps track of data by having classes that can get repositories and saving it</param>
        public Activation(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        ///  Method used to disable account of a user
        /// </summary>
        /// <param name="u1">User object representing user performing the function</param>
        /// <param name="u2">User object representing the user that's having it's account disabled</param>
        /// <returns>disabledAccount = true or false</returns>
        public bool DisableAccount(User u1, User u2)
        {
            bool disabledAccount = true;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
            }
            else
            {
                Console.WriteLine("Error: Account Disabling Failed");
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
            }

            disabledAccount = u2.IsAccountActivated;

            return disabledAccount;
        }

        /// <summary>
        /// Method that enables an account to be used
        /// </summary>
        /// <param name="u1">User object representing the user performing the function</param>
        /// <param name="u2">user object represent the user that's going to have it's account enabled</param>
        /// <returns>enabledAccount = True or False</returns>
        public bool EnableAccount(User u1, User u2)
        {
            bool enabledAccount = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
            }
            else
            {
                Console.WriteLine("Error: Account Enabling Failed");
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
            }

            enabledAccount = u2.IsAccountActivated;

            return enabledAccount;
        }
    }
}
