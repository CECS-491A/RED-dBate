using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    /// <summary>
    /// Enables or disables account of a user
    /// </summary>
    public class Activation
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

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello1");
            }
            else if (u1.Role == "System Admin" && u2.Role == "Admin")
            {
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello2");
            }
            else
            {
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello3" + disabledAccount);
                //throw new Exception("Didn't meet any of the requirements");
            }

            disabledAccount = u2.IsAccountActivated;
            Console.WriteLine("hello4" + disabledAccount);

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

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello1");
            }
            else if (u1.Role == "System Admin" && u2.Role == "Admin")
            {
                u2.IsAccountActivated = true;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello2");
            }
            else
            {
                u2.IsAccountActivated = false;
                _User.Update(u2);
                _uow.Save();
                Console.WriteLine("hello3");
                //throw new Exception("Didn't meet any of the requirements");
            }

            Console.WriteLine("hello4");
            enabledAccount = u2.IsAccountActivated;

            return enabledAccount;
        }
    }
}
