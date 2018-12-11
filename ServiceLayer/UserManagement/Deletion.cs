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
    /// Class used to delete accounts
    /// </summary>
    public class Deletion
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
        public Deletion(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method used to delete account of a user
        /// </summary>
        /// <param name="u1">user object representing user performing the delete function</param>
        /// <param name="u2">user being deleted</param>
        /// <returns>accountDeleted = True or False</returns>
        public bool DeleteAccount(User u1, User u2)
        {
            bool accountDeleted = false;

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                _User.Delete(u2);
                _uow.Save();
                accountDeleted = true;
                //Console.WriteLine("Hello 1");
            }
            else if (u1.Role == "System Admin" && u2.Role == "Admin")
            {
                _User.Delete(u2);
                _uow.Save();
                accountDeleted = true;
                //Console.WriteLine("Hello 2");
            }
            else
            {
                accountDeleted = false;
                //Console.WriteLine("Hello 3");
                //throw new Exception("Didn't meet any of the requirements");
            }

            //Console.WriteLine("Hello 4");

            return accountDeleted;
        }
    }
}
