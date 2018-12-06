using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class Creation
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
        public Creation(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method that checks whether the collection of users contains duplicate usernames
        /// </summary>
        /// <param name="u">user u object</param>
        /// <returns>returns true or false</returns>
        public bool Duplication(User u)
        {
            IEnumerable<User> listUsers = _User.GetAll().AsEnumerable<User>();
            bool duplicate = true;

            // do a seperate method
            foreach (User ur in listUsers)
            {
                if (ur.Username == u.Username)
                {
                    duplicate = false;
                }
            }
            return duplicate;
        }

        /// <summary>
        /// method that creates a user account for them to use
        /// </summary>
        /// <param name="u">User object that contains user information used to create account</param>
        public void CreateAccount(User u)
        {
            bool duplicate = Duplication(u);

            try
            {
                if (u.Role == "Registered User")
                {
                    if (u.Username != null && duplicate != false && u.Password != null && u.DOB != null && u.Location != null)
                    {
                        _User.Add(u);
                        _uow.Save();
                    }
                }
                else if (u.Role == "System Admin" || u.Role == "Admin")
                {
                    if (u.Username != null && u.DOB != null && u.Location != null)
                    {
                        _User.Add(u);
                        _uow.Save();
                    }
                }
                else
                {
                    throw new Exception("Failure Creating an account");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Creating User Account", ex);
            }
        }

    }
}
